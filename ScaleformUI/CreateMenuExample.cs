using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaleformUI.Menu;
using System.Drawing;

namespace Example
{
    internal class ExampleMenu: BaseScript
    {
        UIMenu menu;

        public ExampleMenu() 
        {
            BuildMenu();

            RegisterCommand("Test_Menu", new Action(() => 
            {
                menu.Visible = true;
            }), false);
        }

        private void BuildMenu() 
        {
            menu = new UIMenu("Example Menu", "Example Menu Description", new PointF(20f, 20f), "commonmenu", "interaction_bgd", false, false, 0.1f);

            //Add Items
            UIMenuItem menuItem1 = new UIMenuItem("Menu Item...", "Description...");
            menu.AddItem(menuItem1);

            UIMenuListItem menuListItem = new UIMenuListItem("Menu List: ", new List<dynamic>()
            {
                "Item 1",
                "Item 2",
                "Item 3"
            }, 0);

            //Event Handlers
            menuItem1.Activated += (menu, item) =>
            {
                Debug.WriteLine("Im executing code when menuItem1 is selected!");
            };

            menuListItem.OnListChanged += (item, index) =>
            {
                var selectedItem = item.Items[index];

                Debug.WriteLine($"New Item Selected for Menu List Item: {selectedItem}");
            };
        }
    }
}
