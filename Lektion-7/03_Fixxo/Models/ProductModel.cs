namespace _03_Fixxo.Models
{
    public class ProductModel
    {
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = "";
        public string Category { get; set; } = "";
        public string ShortDescription { get; set; } = "";
        public string LongDescription { get; set; } = "";
        public IEnumerable<ProductReviewModel> Reviews { get; set; } = null!;

        public double Rating()
        {
            if (Reviews != null)
            {
                var rating = 0;

                foreach (var review in Reviews)
                    rating += review.Rating;

                return rating / Reviews.Count();
            }

            return 0;
        }
    }
}
