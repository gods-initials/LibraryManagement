using CommunityToolkit.Mvvm.ComponentModel;

namespace LibraryManagement.Models
{
    public class Tag : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _tag_name;
        public string TagName
        {
            get => _tag_name;
            set => SetProperty(ref _tag_name, value);
        }
        public override string ToString() => $"{Id}: {TagName}";
    }
}
