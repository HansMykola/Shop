using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClientShop.Models
{
    public class ButtonType : Button
    {
        public int IDType { get; set; }
        Action<int> Build { get; set; }

        public ButtonType(Action<int> build)
        {
            Build = build;
            Command = new DelegateCommand(BuildButton);
        }

        private void BuildButton(object obj)
        {
            Build(IDType);
        }
    }
}
