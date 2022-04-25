using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    //sealed pour bloquer l'heritage

    public enum PackagingType
    {
        carton = 0 ,
        plastic = 1
    }
   public class Product : Concept
    {

        //public Product(int ProductId, string Name, double Price, DateTime DateProd, string  Description, int Quantity, Category Category){
        ////    this.ProductId = ProductId;
        ////    this.Name = Name;
        ////    this.Price = Price;
        ////    this.DateProd = DateProd;
        ////    this.Description = Description;
        ////    this.Quantity = Quantity;
        ////    this.Category = Category;
        //}

        public Product()
        {

        }

        public override string ToString()
        {
            return "Name : " + Name + " Description : " + Description + " Quantity : " + Quantity; 
        }



        public int ProductId { get; set; }

        [Required(ErrorMessage ="name required")]
        [MaxLength(25,ErrorMessage =("only 25 chars"))]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Display(Name="Production Date")]
        [DataType(DataType.Date)]
        public DateTime DateProd { get; set; }

        public string ImageName { get; set; }

        [DataType(DataType.MultilineText)]
        public string  Description { get; set; }

        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        //[ForeignKey("CategoryFK")]
        public virtual Category Category { get; set; }

        [ForeignKey("Category")]
        public  int? CategoryFK { get; set; }

        public virtual List<Provider> Providers {get; set;}

        public virtual List<Achat> Achats { get; set; }


        //passage par reference
        public void calculer(int a , int b , ref int c)
        {
            c = a + b;
            Console.WriteLine(c);

        }

        public virtual void GetMyName()
        {
            Console.WriteLine("je suis un produit");        
        }

        public override void getDetails()
        {
            throw new NotImplementedException();
        }

        public PackagingType PackagingType { get; set; }

    }
}
