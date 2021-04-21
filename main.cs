using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
public class Book{
   public string isbn;
   string title;
   string author_info;
   DateTime published_on;
   string published_by="Unknown";
   public Book(string isbn,string title,string author_info){
           this.isbn=isbn;
           this.title=title;
           this.author_info=author_info;
           DateTime dt=DateTime.Now;
           this.published_on=dt;
   }
   public void setAuthorInfo(String fname,String lname){
       this.author_info=fname+" "+lname;
   }
   public Book(string isbn,string title,string author_info,DateTime published_on,string published_by):this(isbn,title,author_info){
       this.published_on=published_on;
       this.published_by=published_by;
   }
   public void Display(){
       string d=published_on.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture);
       Console.WriteLine("Book "+title+" was written by "+author_info+" and published on "+d);
   }
}
public class Person{
   public string fname;
   public string lname;
   public string email;
   public Person(string fname,string lname,string email){
       this.fname=fname;
       this.lname=lname;
       this.email=email;
   }
}
public class Author:Person{
   private List<Book> book=new List<Book>();
   public Author(string fname,string lname,string email):base(fname,lname,email){}
   public void DisplayInfo(){
       Console.WriteLine(fname+" "+lname+" "+email);
   }
   public void DisplayBooks(){
       foreach(var item in book){
           item.Display();
       }
   }
   public void AddBook(Book b){
       b.setAuthorInfo(fname,lname);
       book.Add(b);
   }
   public void RemoveBook(string isbn){
       int i=0;
       foreach(var item in book){
           if(string.Compare(item.isbn,isbn)==1){
               break;
           }
           i++;
       }
       book.RemoveAt(i);
   }
}
public class Program{
   public static void Main(string[] args){
       Book b1=new Book("1","Title 1",null);
       Book b2=new Book("2","Title 2",null);
       Book b3=new Book("3","Title 3",null);
       DateTime d1,d2,d3;
       d1=new DateTime(1976,11,18);
       Book b4=new Book("4","Title 4",null,d1,"person1");
       d2=new DateTime(1913,11,19);
       Book b5=new Book("5","Title 5",null,d2,"person2");
       d3=new DateTime(2005,11,20);
       Book b6=new Book("6","Title 6",null,d3,"person3");
       Author a1=new Author("fname1","lname1","id 1");
       Author a2=new Author("fname2","lname2","id 2");
       a1.DisplayInfo();
       a2.DisplayInfo();
       a1.AddBook(b1);
       a1.AddBook(b3);
       a1.AddBook(b5);
       a1.DisplayBooks();
       a2.AddBook(b2);
       a2.AddBook(b6);
       a2.AddBook(b6);
       a2.DisplayBooks();
       a1.RemoveBook(b1.isbn);
       Console.WriteLine("After removing book....");
       a1.DisplayBooks();
   }
   }