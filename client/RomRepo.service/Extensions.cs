using RomRepo.service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service
{
    public static class Extensions
    {

        public static IEnumerable<DirectoryInfoViewModel> ToViewModel(this IEnumerable<DirectoryInfo> models)
        {
            var viewModels = new List<DirectoryInfoViewModel>();
            foreach(var model in models)
            {
                viewModels.Add(new DirectoryInfoViewModel { 
                    Name = model.Name,
                    Parent = model.Parent?.Name,
                    FullPath = model.FullName,
                });
            }
            return viewModels;
        }
    }
}
