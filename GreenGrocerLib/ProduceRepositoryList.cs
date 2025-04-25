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
                new Produce(1004, "Kiwi", "8pcs", 25, 80, "./resources/Kiwi-fruit.webp")
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

            if (!string.IsNullOrWhiteSpace(updatedFields.Item))
                produceToUpdate.Description = updatedFields.Item;

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
