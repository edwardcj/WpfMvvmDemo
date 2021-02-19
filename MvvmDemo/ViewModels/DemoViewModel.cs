using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmDemo.Models;
using MvvmDemo.Commands;

using System.Collections.ObjectModel;
namespace MvvmDemo.ViewModels
{
    class DemoViewModel : INotifyPropertyChanged
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

        DemoService ObjService;

        public DemoViewModel(string s)
        {
            Message = s;
            ObjService = new DemoService();
            loadData();
            CurrentModel = new DemoModel();
            SaveCommand = new RelayCommand(Save);
            SearchCommand = new RelayCommand(Search);
            UpdateCommand = new RelayCommand(Update);
            DeleteCommand = new RelayCommand(Delete);
        }

        #region display operation
        private ObservableCollection<DemoModel> _objModelList;

        public ObservableCollection<DemoModel> ObjModelList
        {
            get { return _objModelList; }
            set { _objModelList = value; OnPropertyChanged(); }
        }

        private void loadData()
        {
            ObjModelList = new ObservableCollection<DemoModel>(ObjService.GetAll());
        }
        #endregion

        private DemoModel currentModel;

        public DemoModel CurrentModel
        {
            get { return currentModel; }
            set { currentModel = value; OnPropertyChanged(); }
        }

        #region SAVE command
        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
            set { _saveCommand = value; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjService.AddObj(CurrentModel);
                if (IsSaved)
                {
                    Message = "Saved!";

                    loadData();
                }
                else
                    Message = "Not saved!";
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region SEARCH command
        private RelayCommand _searchCommand;

        public RelayCommand SearchCommand
        {
            get { return _searchCommand; }
            set { _searchCommand = value; }
        }

        public void Search()
        {
            try
            {
                var obj = ObjService.Search(CurrentModel.Id);
                if(obj == null)
                {
                    Message = "there is no item has id " + CurrentModel.Id;
                    return;
                }
                Message = "search complete";
                CurrentModel.Age = obj.Age;
                CurrentModel.Name = obj.Name;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region UPDATE command
        private RelayCommand _updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return _updateCommand; }
            set { _updateCommand = value; }
        }

        public void Update()
        {
            try
            {
                var isUpdated = ObjService.Update(CurrentModel);
                
                Message = "update " + (isUpdated ? "success" : "failed");
                
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region DELETE command
        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return _deleteCommand; }
            set { _deleteCommand = value; }
        }

        public void Delete()
        {
            try
            {
                var isDelete = ObjService.Delete(CurrentModel.Id);

                Message = "delete " + (isDelete ? "success" : "failed");

                if (isDelete)
                    loadData();

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

    }
}
