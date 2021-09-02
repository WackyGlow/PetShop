using System.Threading;

namespace Thyr.PetShop.UI
{
    public interface IMenu
    {
        void Start();

        int GetMainMenuSelection();
    }
}