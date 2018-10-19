﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace TimerControl
{
  
    public partial class main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public main()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            
            Timers.Add(new TimerView() { Name = "线路排故" });
            Timers.Add(new TimerView() { Name = "保险" });
            Timers.Add(new TimerView() { Name = "部件拆装" });
        }
        public List<TimerView> Timers=new List<TimerView>();
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}