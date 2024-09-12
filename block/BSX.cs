using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
namespace block
{
    internal class BSX
    {

        String id;
        String itemname;
        String categoryname;
        String colorname;
        int qty;

        public BSX(string id, string itemname, string categoryname, string colorname, int qty)
        {
            this.id = id;
            this.itemname = itemname;
            this.categoryname = categoryname;
            this.colorname = colorname;
            this.qty = qty;
        }

        public string Id { get => id; set => id = value; }
        public string Itemname { get => itemname; set => itemname = value; }
        public string Categoryname { get => categoryname; set => categoryname = value; }
        public string Colorname { get => colorname; set => colorname = value; }
        public int Qty { get => qty; set => qty = value; }
    }
}
