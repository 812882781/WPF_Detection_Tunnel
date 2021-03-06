﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Detection
{
    class STU_Binding : INotifyPropertyChanged
    {
        private string _date;

        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                if (PropertyChanged != null)
                {
                    //对Date属性监听
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Date"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void Show()
        {
            List<string> Dictionaries = new List<string>();
            Dictionaries.Add("Start detection..."+ "\r\n");
            Dictionaries.Add("Call YOLOv5..."+ "\r\n");
            Dictionaries.Add("Finish..."+ "\r\n");
            Date = null;
            //Task.Run
            //    (
            //    async () =>
            //    {
            //        int i = 0;
            //        while (i<3)
            //        {
            //            await Task.Delay(1000);

            //            Date += Dictionaries[i];
            //            i++;
            //        }
            //        await Task.Delay(1000);
            //        Date = "";
            //    }
            //    );
            //;
            Date += Dictionaries[0];
           

        }

        
    }
}
