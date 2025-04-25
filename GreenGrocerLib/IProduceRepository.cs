
namespace GreenGrocerLib
{
    public interface IProduceRepository
    {
        Produce Add(Produce produce);
        Produce? Delete(int barcode);
        Produce? Get(int barcode);
        List<Produce>? GetAll();
        Produce? Update(int barcode, UpdateProduceDTO updatedFields);
    }
}