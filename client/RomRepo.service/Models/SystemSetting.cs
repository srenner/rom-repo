using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Models
{
    public class SystemSetting : INotifyPropertyChanged
    {
        private string _value;

        [Key]
        public string Name { get; set; }
        public string Value { 
            get 
            { 
                return _value; 
            }
            set 
            { 
                if(value != _value)
                {
                    _value = value;
                    OnValueChanged("Value");
                }
            } 
        }

        protected void OnValueChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected void OnValueChanged(string propertyName)
        {
            OnValueChanged(new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}


