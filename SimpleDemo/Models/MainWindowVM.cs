using System;
using Microsoft.Win32;
using SimpleDemo.Commands;
using SimpleDemo.ViewModels;

namespace SimpleDemo.Models
{
    public class MainWindowVM : NotificationObject
    {
        private double input1;

        public double Input1
        {
            get => input1;
            set
            {
                input1 = value;
                OnPropertyChanged(nameof(Input1));
            }
        }

        private double input2;

        public double Input2
        {
            get => input2;
            set
            {
                input2 = value;
                OnPropertyChanged(nameof(Input2));
            }
        }

        private double result;

        public double Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public DelegateCommand AddCommand { get; set; }

        private void Add(object parameter)
        {
            Result = Input1 + Input2;
        }

        public DelegateCommand SaveCommand { get; set; }

        private void Save(object parameter)
        {
            var sfd = new SaveFileDialog();
            sfd.ShowDialog();
        }

        public MainWindowVM()
        {
            AddCommand = new DelegateCommand
            {
                ExecuteAction = Add
            };

            SaveCommand = new DelegateCommand
            {
                ExecuteAction = Save
            };
        }
    }
}