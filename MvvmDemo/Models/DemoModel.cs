using System;
using System.Collections.Generic;
using System.Text;


using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace MvvmDemo.Models
{
    class DemoModel : INotifyPropertyChanged
    {
        #region propertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName)); //propertyName = null?
        }
        #endregion


        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }
    }
}
