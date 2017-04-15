using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Lets the program use the RPG_Source files. 
using RPG_Source;
namespace RPGSKELETON
{
    public partial class UI : Form
    {
        private Player _player;

        public UI()
        {
            InitializeComponent();
            //constructors that call for all the items locations and so on
            Location location = new Location(1,"Home","This is your home");
            Player player = new Player(10, 10, 20, 0, 1);
            //_player = new Player();

            //_player.CHP = 10;
            //_player.MHP = 10;
            //_player.Gold = 20;
            //_player.Exp = 0;
            //_player.Lvl = 1;

            HPlabel.Text = _player.CHP.ToString();
            Goldlabel.Text = _player.Gold.ToString();
            EXPlabel.Text = _player.Exp.ToString();
            LevelLable.Text = _player.Lvl.ToString();
        }
    }
}
