using HttpTest.Commands;
using HttpTest.Models;
using HttpTest.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HttpTest.ViewModels
{
    public class HumanViewModel:BaseViewModel
    {
		private ObservableCollection<Human> allHumans;

		public ObservableCollection<Human> AllHumans
		{
			get { return allHumans; }
			set { allHumans = value; OnPropertyChanged(); }
		}

		private HumanCreateModel current;

		public HumanCreateModel Current
        {
			get { return current; }
			set { current = value; OnPropertyChanged(); }
		}

		public RelayCommand DeleteCommand { get; set; }
		public RelayCommand CreateCommand { get; set; }
        public HumanService HumanService { get; set; }

		private Human selectedHuman;

		public Human SelectedHuman
		{
			get { return selectedHuman; }
			set { selectedHuman = value; OnPropertyChanged(); }
		}


        public HumanViewModel()
        {
			Current = new HumanCreateModel();
			HumanService = new HumanService();
			SelectedHuman = new Human();

			DeleteCommand = new RelayCommand(async (obj) =>
			{
				var id = int.Parse(obj.ToString());
				var result = await HumanService.DeleteById(id);
				MessageBox.Show(result);
			});

			CreateCommand = new RelayCommand(async (obj) =>
			{

				var response = await HumanService?.AddHumanAsync(Current);
				MessageBox.Show($@"
					{response.Name}
		created at {response.CreatedAt} with this id : {response.Id}
");
			});

			LoadHumans();
        }

        private async void LoadHumans()
        {
			AllHumans = new ObservableCollection<Human>(await HumanService.GetAllAsync());
        }
    }
}
