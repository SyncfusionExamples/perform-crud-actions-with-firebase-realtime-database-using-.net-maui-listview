using Syncfusion.Maui.DataForm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ListViewMAUI
{
    public class ContactInfo : INotifyPropertyChanged
    {
        int _id;
        string _profileImage; 
        string _phonenumber;
        string _contactname;
        string _maskedMobileText;

        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [DataFormDisplayOptions(ColumnSpan = 2, ShowLabel = false)]
        public string ContactImage { get; set; }

        [Display(ShortName = "Contact name")]
        [Required(ErrorMessage = "Name should not be empty")]
        public string ContactName
        {
            get { return _contactname; }
            set
            {
                _contactname = value;
                RaisePropertyChanged(nameof(ContactName));
            }
        }

        [Display(ShortName = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber
        {
            get { return _phonenumber; }
            set
            {
                _phonenumber = value;
                if (!string.IsNullOrEmpty(_phonenumber))
                {
                    char[] specialCharacters = { '(', ')', '-', ' ' };
                    if (_phonenumber[0] == specialCharacters[0])
                    {
                        _phonenumber = new string(value.Where(c => Char.IsLetterOrDigit(c)).ToArray());
                    }
                    if (_phonenumber.Length == 10)
                        this.ContactNumber = string.Format("({0}) {1}-{2}", _phonenumber.Substring(0, 3), _phonenumber.Substring(3, 3), _phonenumber.Substring(6));
                    RaisePropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        [Display(AutoGenerateField = false)]
        public string ContactNumber
        {
            get { return _maskedMobileText; }
            set
            {
                this._maskedMobileText = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    class ContactsInfoRepository
    {
        private Random random = new Random();

        public ObservableCollection<ContactInfo> GetContactDetails(int count)
        {
            ObservableCollection<ContactInfo> customerDetails = new ObservableCollection<ContactInfo>();
            int girlsCount = 0, boysCount = 0;
            for (int i = 0; i < count; i++)
            {
                var details = new ContactInfo()
                {
                    Id = i + 1,
                    PhoneNumber = random.Next(100, 400).ToString() + random.Next(500, 800).ToString() + random.Next(1000, 2000).ToString(),
                    ContactImage = "People_Circle" + (i % 19) + ".png",
                };

                if (imagePosition.Contains(i % 19))
                    details.ContactName = CustomerNames_Boys[boysCount++ % 32];
                else
                    details.ContactName = CustomerNames_Girls[girlsCount++ % 93];

                customerDetails.Add(details);
            }
            return customerDetails;
        }


        int[] imagePosition = new int[]
        {
            5,
            8,
            12,
            14,
            18
        };

        string[] CustomerNames_Girls =
        [
            "Kylie",
            "Gina",
            "Brenda",
            "Danielle",
            "Fiona",
            "Lila",
            "Jennifer",
            "Liz",
            "Pete",
            "Katie",
            "Vince",
            "Fiona",
            "Liam   ",
            "Georgia",
            "Eliana",
            "Alivia",
            "Evan   ",
            "Ariel",
            "Vanessa",
            "Gabriel",
            "Angelina",
            "Eli    ",
            "Remi",
            "Levi",
            "Alina",
            "Layla",
            "Ella",
            "Mia",
            "Emily",
            "Clara",
            "Lily",
            "Melanie",
            "Rose",
            "Brianna",
            "Bailey",
            "Juliana",
            "Valerie",
            "Hailey",
            "Daisy",
            "Sara",
            "Victoria",
            "Grace",
            "Layla",
            "Josephine",
            "Jade",
            "Evelyn",
            "Mila",
            "Camila",
            "Chloe",
            "Zoey",
            "Nora",
            "Ava",
            "Natalia",
            "Eden",
            "Cecilia",
            "Finley",
            "Trinity",
            "Sienna",
            "Rachel",
            "Sawyer",
            "Amy",
            "Ember",
            "Rebecca",
            "Gemma",
            "Catalina",
            "Tessa",
            "Juliet",
            "Zara",
            "Malia",
            "Samara",
            "Hayden",
            "Ruth",
            "Kamila",
            "Freya",
            "Kali",
            "Leiza",
            "Myla",
            "Daleyza",
            "Maggie",
            "Zuri",
            "Millie",
            "Lilliana",
            "Kaia",
            "Nina",
            "Paislee",
            "Raelyn",
            "Talia",
            "Cassidy",
            "Rylie",
            "Laura",
            "Gracelynn",
            "Heidi",
            "Kenzie",
        ];

        string[] CustomerNames_Boys = new string[]
        {
            "Ivan",
            "Watson",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Howard",
            "Daniel",
            "Frank",
            "Jack",
            "Oscar",
            "Larry",
            "Holly",
            "Steve",
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason",
            "Jacob  ",
            "Jayden ",
            "Ethan  ",
            "Noah   ",
            "Lucas  ",
            "Brayden",
            "Logan  ",
            "Caleb  ",
            "Caden  ",
            "Benjamin",
            "Xaviour",
            "Ryan   ",
            "Connor ",
            "Michael",
        };
    }
}
