﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RomRepo.api.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RomRepo.api.DataAccess
{
    public class ApiRepository : IApiRepository
    {
        private ApiContext _context;
        private ILogger<ApiRepository> _logger;
        public ApiRepository(ApiContext context, ILogger<ApiRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ApiKey> SaveKey(ApiKey apiKey)
        {
            try
            {
                await _context.AddAsync(apiKey);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return apiKey;
        }

        public async Task<IEnumerable<ApiKey>> GetKeyByEmail(string emailAddress)
        {
            try
            {
                //return await _context.ApiKey.Where(w => w.Email.Equals(emailAddress, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
                return await _context.ApiKey.Where(w => w.Email == emailAddress).ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in ApiRepository.GetKey(emailAddress: {emailAddress})", emailAddress, ex);
                return null;
            }
        }

        public async Task<int> GetKeyStatus(string key)
        {
            try
            {
                var apiKey = await _context.ApiKey.Where(w => w.Key == key).FirstOrDefaultAsync();
                return apiKey != null ? apiKey.Status : (int)ApiKeyStatus.Unknown;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return (int)ApiKeyStatus.Unknown;
            }
        }

        public async Task SetKeyStatus(string key, ApiKeyStatus status)
        {
            int newStatusID = (int)status;

            try
            {
                var keyEntity = await _context.ApiKey.Where(w => w.Key == key).FirstOrDefaultAsync();
                if (keyEntity != null)
                {
                    keyEntity.Status = newStatusID;
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {

            }

        }

        public async Task<bool> AddGameSystemWithGames(GameSystem gameSystem)
        {
            try
            {
                await _context.AddAsync(gameSystem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                var name = gameSystem.Name;
                _logger.LogError($"Error in ApiRepository.AddGameSystemWithGames(gameSystem: {name})", name, ex);
                return false;
            }
        }

        public async Task<GameSystem> GetGameSystem(int id)
        {
            try
            {
                return await _context.GameSystem.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in ApiRepository.GetGameSystem(id: {id})", id, ex);
                return null;
            }
        }

        public async Task<IEnumerable<Rom>> GetRomsByChecksum(ChecksumType checksumType, string val)
        {
            try
            {
                var roms = _context.Rom.AsQueryable();

                //todo room for improvement
                switch (checksumType)
                {
                    case ChecksumType.CRC:
                        roms = roms.Where(w => w.CRC == val);
                        break;
                    case ChecksumType.MD5:
                        roms = roms.Where(w => w.MD5 == val);
                        break;
                    case ChecksumType.SHA1:
                        roms = roms.Where(w => w.SHA1 == val);
                        break;
                    case ChecksumType.SHA256:
                        roms = roms.Where(w => w.SHA256 == val);
                        break;
                }
                return await roms.Include(i => i.Game.GameSystem).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("oops");
                return null;
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rom>> GetRomsByChecksum(string checksum)
        {
            try
            {
                var roms = await _context.Rom
                    .Include(i => i.Game.GameSystem)
                    .Where(w => w.CRC == checksum || w.MD5 == checksum || w.SHA1 == checksum || w.SHA256 == checksum)
                    .ToListAsync();
                return roms;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in ApiRepository.GetRomsByChecksum(checksum: {checksum})", checksum, ex);
                return null;
            }
        }

    }
}
