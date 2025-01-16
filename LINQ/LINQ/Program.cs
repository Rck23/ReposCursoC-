LinqQueries queries = new LinqQueries(); 

PrintValues(queries.LibrosDespuesDel2005ConMasDe500Pag ()); 


void PrintValues(IEnumerable<Book> books){
    Console.WriteLine("{0, -70} {1, 7} {2, 11}\n", "Titulo", "# paginas", "Fecha publicacion");

    foreach(var book in books){
        System.Console.WriteLine("{0, -70} {1, 7} {2, 11}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString);
    }
}