using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Introduction.ViewModels
{
    public sealed class MainViewModel : ObservableObject
    {
        private int? _count;
        public int? Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public ICommand IncrementCountCommand { get; }

        public MainViewModel()
        {
            IncrementCountCommand = new Command(IncrementCount);
        }

        private void IncrementCount()
        {
            Count = Count + 1 ?? 1;
        }
    }
}
