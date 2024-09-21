using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase
    {
        public int PictuerId { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public bool IsRemoved { get; set; }
        public Product Product { get; private set; }
        public int ProductId { get; set; }

        public ProductPicture(int pictuerId, string picture, string pictureAlt, string pictureTitle)
        {
            PictuerId = pictuerId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemoved = false;
        }


        public void Edit(int pictuerId, string picture, string pictureAlt, string pictureTitle)
        {
            PictuerId = pictuerId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
