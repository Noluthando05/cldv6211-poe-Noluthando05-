using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace KhumaloCraftReg_2.Pages.Products
{
	public class CreateModel : PageModel
    {
        public ProductInfo productInfo = new ProductInfo();
        public string errormessage = "";
        public string successMessage = "";
        public void OnGet()
        {

        }
        public void OnPost() 
        
        {
            productInfo.product_name = Request.Form["product_name"];
               productInfo.availability = Request.Form["availability"];
			productInfo.category = Request.Form["category"];
			productInfo.ratings =Request.Form["ratings"];
            productInfo.ratings = Request.Form["price"];

			if (productInfo.product_name.Length == 0||productInfo.price.Length == 0 ||productInfo.availability.Length == 0 ||
				productInfo.category.Length == 0 ||productInfo.ratings.Length==0)
            {

                errormessage = "All the fields are required";
                return;
            }

		

			try

			{
                String connectionString = "Data Source=NOLUTHANDO;Initial Catalog=MyProducts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                using(SqlConnection connection = new SqlConnection(connectionString))
                
                
                {
                 connection.Open();
                    String sql = "Insert INTO products" + "( product_name ,price,category,availibility,ratings) VALUES " +
  "(@product_name,@price,@category,@availibility,@ratings);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    
                    {
                       
 command.Parameters.AddWithValue("@product name",productInfo.product_name);
                        command.Parameters.AddWithValue("@price", productInfo.price);
							 command.Parameters.AddWithValue(@"category", productInfo.category);
                        command.Parameters.AddWithValue("@availibility", productInfo.availability);
                        command.Parameters.AddWithValue("@ratings", productInfo.ratings);

                        command.ExecuteNonQuery();

					}

                }
			}

            catch (Exception ex)
			{
                errormessage = ex.Message;
                return;
            
            }


            productInfo.product_name = "";
            productInfo.price = "";
            productInfo.availability = "";
            productInfo.ratings = "";
            productInfo.category = "";

            successMessage = "New Product Added Correctly";

            Response.Redirect("/Products/Index");
            
		}
    }
}
