﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MillSuppoter
{

    public partial class Toilet : Form
    {
        private Pen pBlue,pRed;

        public Toilet()
        {
            InitializeComponent();
        }

        private void Toilet_Load(object sender, EventArgs e)
        {
            pBlue = new Pen(Color.Blue);
            pRed = new Pen(Color.Red);

        }

        private void Toilet_Paint(object sender, PaintEventArgs e)
        {
            const int RectWitdh = 100;
            const int RectHeight = 120;

            Pen pTemp;
            for(int i = 0; i < 5; i++)
            {
                pTemp = pBlue;
                e.Graphics.DrawRectangle(pTemp, new Rectangle(10 + (i * (RectWitdh + 10)), 40, RectWitdh, RectHeight));
            }
        }
    }

    public class TltRoom
    {
        private bool isPeople;

        public TltRoom()
        {
            isPeople = false;
        }
    }
}
