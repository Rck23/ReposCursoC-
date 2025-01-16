public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
       using(StreamReader reader = new StreamReader("Book.json")){
        string json = reader.ReadToEnd();

        this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
 
       }

    }

    public IEnumerable<Book> TodaLaColeccion(){
        return librosCollection;
    }
    
    public IEnumerable<Book> LibrosDespuesDel2000(){

        // extension method 
        return librosCollection.Where(p => p.PublishedDate.Year > 2000); 

        // query expresion
       
       // return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosConMasde250PagYPalabrasInAction(){
        return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));  
    }

    public bool TodosLosLibrosTienenStatus(){
         return librosCollection.All(p => p.Status != string.Empty);
    }
    
    public bool AlgunLibroPublicadoEn2005(){
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosDePython(){
        return librosCollection.Where(p => p.Categories.Contains("Python"));
    }

     public IEnumerable<Book> LibrosDeJavaAsd(){
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(n => n.Title);

     }

    public IEnumerable<Book> LibrosConMasde450PagYOrderDesc(){
        return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);  
    }


     public IEnumerable<Book> TresPrimeroLibroJava(){
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(n => n.PublishedDate).Take(3);

     }

      public IEnumerable<Book> LibrosConMas400Pag(){
        return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);

     }

     public IEnumerable<Book> TresPrimerosLibrosDeLaColeccion(){
        return librosCollection.Take(3).Select(p => new Book() {Title = p.Title, PageCount = p.PageCount});
     }

    public Book LibroMenorCantidadDePag(){ 
        return librosCollection.Where(p => p.PageCount >0).MinBy(p => p.PageCount);
    }

    public string TitulosDeLibrosDespuesDel2015Concatenados(){
        return librosCollection.Where(p => p.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) => {
            if(TitulosLibros != string.Empty){
                TitulosLibros += " - " + next.Title;
            }else{
                TitulosLibros += next.Title;
            }
            return TitulosLibros; 
        });
    }

    public double PromedioCaracteresTitulo(){
        return librosCollection.Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDEspuesDel2000AgrupadosPorYear(){
        return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(g => g.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionariosDeLibrosPorLetra(){
        return librosCollection.ToLookup(p => p.Title[0], p => p);
    }

    public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Pag(){
        var LibrosDespuesDel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005); 

        var LibrosConMas500Pag = librosCollection.Where(p => p.PageCount >500);

        return LibrosDespuesDel2005.Join(LibrosConMas500Pag,  p => p.Title, x => x.Title, (p,x) => p);
    }
}