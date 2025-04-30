using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGrocerLib
{
    public class ProduceRepositoryList : IProduceRepository
    {
        private readonly List<Produce> produceList;

        public ProduceRepositoryList()
        {
            produceList = new List<Produce>()
            {
                new Produce(1000, "Green Apple", "6pcs", 20, 100, "./resources/green-apple.jpg"),
                new Produce(1001, "Broccoli", "1pc", 10, 15, "./resources/broccoli.jpg"),
                new Produce(1002, "Cherry Tomato", "500g", 15, 75, "./resources/cherry-tomatoes.webp"),
                new Produce(1003, "Russet Potato", "1kg", 18, 50, "./resources/potatoes.jpg"),
                new Produce(1004, "Kiwi", "8pcs", 25, 80, "./resources/Kiwi-fruit.webp"),
                new Produce(1005, "Strawberries", "500g", 30, 75, "https://allmanhall.co.uk/wp-content/uploads/2019/06/Strawberries-on-white-background.jpg"),
                new Produce(1006, "Cucumber", "1pc", 10, 75, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQT19UUTLodCwKT1sEjgfdbWn8WLfiJ3D2d4Q&s"),
                new Produce(1007, "Banana", "6pcs", 18, 90, "https://organicmandya.com/cdn/shop/files/BananaPachabale.jpg?v=1721369894&width=1000"),
                new Produce(1008, "Red Bell Pepper", "1pc", 12, 60, "https://palengkego.shop/cdn/shop/products/redpepper_1024x1024@2x.jpg?v=1622617686"),
                new Produce(1009, "Blueberries", "250g", 28, 50, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzMoAB-DOu1G765J0dEE9nxZn75z47Cmf_Fg&s"),
                new Produce(1010, "Carrots", "1kg", 15, 100, "https://healthyschoolrecipes.com/wp-content/uploads/2018/11/carrots.jpg"),
                new Produce(1011, "Pineapple", "1pc", 35, 40, "https://organicmandya.com/cdn/shop/files/Pineapple.jpg?v=1721375225&width=1000"),
                new Produce(1012, "Zucchini", "1pc", 9, 70, "https://chefsmandala.com/wp-content/uploads/2018/03/Squash-Zucchini.jpg"),
                new Produce(1013, "Avocado", "2pcs", 22, 50, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUIHNX5zabyT40tsjSGEMCzHgs-5yu7JW3xA&s"),
                new Produce(1014, "Spinach", "300g", 14, 85, "https://bedford.tennessee.edu/wp-content/uploads/sites/162/2020/08/spinach-leaves-1024x593.jpg"),
                new Produce(1015, "Mango", "2pcs", 30, 60, "https://www.hjemmebryggeren.dk/files/products/1865/1/mango1.webp"),
                new Produce(1016, "Lettuce", "1pc", 10, 40, "https://media.newyorker.com/photos/5b6b08d3a676470b4ea9b91f/master/pass/Rosner-Lettuce.jpg"),
                new Produce(1017, "Orange", "5pcs", 20, 75, "https://exoticflora.in/cdn/shop/products/exoticflorakinnow_1024x1024.jpg?v=1620208006"),
                new Produce(1018, "Red Grapes", "500g", 26, 65, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTMgGH1N5LZnu1Qt1tg0aKTR7OjawOUkTVtA&s"),
                new Produce(1019, "Sweet Potato", "1kg", 20, 45, "https://images.immediate.co.uk/production/volatile/sites/30/2020/02/Sweet-potatoes-ca0d8f4.jpg?quality=90&resize=556,505"),
                new Produce(1020, "Celery", "1 bunch", 18, 30, "https://images.squarespace-cdn.com/content/v1/5d96d524052c897425394aaf/7176474d-8019-4ea7-beba-69538745085f/celery.jpeg")
            };
        }

        public List<Produce>? GetAll()
        {
            return produceList.Count == 0 ? null : produceList;
        }

        public Produce? Get(int barcode)
        {
            var output = produceList.First(x => x.Barcode == barcode);

            return output == null ? null : output;
        }

        public Produce Add(Produce produce)
        {
            produceList.Add(produce);
            return produce;
        }

        public Produce? Update(int barcode, UpdateProduceDTO updatedFields)
        {
            var produceToUpdate = produceList.FirstOrDefault(x => x.Barcode == barcode);

            if (produceToUpdate == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updatedFields.Description))
                produceToUpdate.Description = updatedFields.Description;

            if (!string.IsNullOrWhiteSpace(updatedFields.Amount))
                produceToUpdate.Amount = updatedFields.Amount;

            if (!string.IsNullOrWhiteSpace(updatedFields.Image))
                produceToUpdate.Image = updatedFields.Image;

            if (updatedFields.Price.HasValue)
                produceToUpdate.Price = updatedFields.Price.Value;

            if (updatedFields.Quantity.HasValue)
                produceToUpdate.Quantity = updatedFields.Quantity.Value;

            return produceToUpdate;
        }

        public Produce? Delete(int barcode)
        {
            var itemToDelete = produceList.FirstOrDefault(x => x.Barcode == barcode);

            if (itemToDelete == null)
                return null;

            produceList.Remove(itemToDelete);

            return itemToDelete;
        }
    }
}
