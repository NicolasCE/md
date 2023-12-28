using ccharp6.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

//mostrar pacientes
app.MapGet("/app/ver/pacientes", () =>
{
    mdddContext db = new mdddContext();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});

//añadir paciente
app.MapPost("/app/pacientes/add", (Paciente paciente) =>
{
    mdddContext db = new mdddContext();
    db.Pacientes.Add(paciente);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("paciente agregado");
    else
        return Results.Problem();
});

//eliminar paciente por rut
app.MapDelete("/app/pacientes/eliminar/{rut}", (string rut) =>
{
    mdddContext db = new mdddContext();
    var paciente = new Paciente { Rut = rut };
    db.Entry(paciente).State = EntityState.Deleted;
    int k = db.SaveChanges();
    return k == 0 ? Results.Problem() : Results.Ok("Paciente Eliminado");
});

//eliminar profesional x rut
app.MapDelete("/app/profesional/eliminar/{rut}", (string rut) =>
{
    mdddContext db = new mdddContext();
    var profe = new Profesional { Rut = rut };
    db.Entry(profe).State = EntityState.Deleted;
    int k = db.SaveChanges();
    return k == 0 ? Results.Problem() : Results.Ok("Profesional Eliminado");
});

//mostrar pacientes
app.MapGet("/app/pacientes", () =>
{
    mdddContext db = new mdddContext();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});

//mostrar profesionales
app.MapGet("/app/profesionales", () =>
{
    mdddContext db = new mdddContext();
    var lista = db.Profesionals.ToList();
    return Results.Ok(lista);
});


//añadir especialista
app.MapPost("/app/profesional/add", (Profesional profesional) =>
{
    mdddContext db = new mdddContext();
    db.Profesionals.Add(profesional);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("profesional agregado");
    else
        return Results.Problem();
});

//editar perfiles pacientes 
app.MapPut("/app/pacientes/edit", (Paciente paciente) =>
{
    System.Console.WriteLine(paciente.Rut);
    //System.Console.WriteLine(paciente.Nombre);
    mdddContext db = new mdddContext();
    var pacientess2 = db.Pacientes.FirstOrDefault(p => p.Rut == paciente.Rut);
    System.Console.WriteLine(pacientess2);
    //pacientess2.Rut = paciente.Rut;
    pacientess2.Nombre = paciente.Nombre;
    pacientess2.FechaNac = paciente.FechaNac;
    pacientess2.Apellidos = paciente.Apellidos;
    pacientess2.Telefono = paciente.Telefono;
    pacientess2.Correo = paciente.Correo;
    pacientess2.Sexo = paciente.Sexo;
    pacientess2.Edad = paciente.Edad;
    pacientess2.Peso = paciente.Peso;
    pacientess2.Descripcion = paciente.Descripcion;
    db.Entry(pacientess2).State = EntityState.Modified;
    int element = db.SaveChanges();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});

//editar la dieta
app.MapPut("/app/dieta/edit", (DietaColacion dieta) =>
{
    {
        System.Console.WriteLine(dieta.Id);
        mdddContext db = new mdddContext();
        var dietaa2 = db.DietaColacions.FirstOrDefault(p => p.Id == dieta.Id);
        System.Console.WriteLine(dietaa2);
        dietaa2.Nombre = dieta.Nombre;
        dietaa2.TipoComida = dieta.TipoComida;
        dietaa2.TipoVegan = dieta.TipoVegan;
        db.Entry(dietaa2).State = EntityState.Modified;
        int element = db.SaveChanges();
        var lista = db.DietaColacions.ToList();
        return Results.Ok(lista);
    }
});

//añadir citas
app.MapPost("/app/citas/add", (SeguimientoCitum citum) =>
{
    mdddContext db = new mdddContext();
    db.SeguimientoCita.Add(citum);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("cita agregada");
    else
        return Results.Problem();
});

//--------------------------------------------------------------------------------------------

//MODULO PROFESIONAL
//Crear dietas
/*app.MapPost("/app/dietas/add", (DietaColacion w) =>
{
    mdddContext db = new mdddContext();
    db.DietaColacions.Add(w);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("dieta agregada");
    else
        return Results.Problem();
});
*/

//eliminar dieta x id
app.MapDelete("/app/dietas/eliminar/{id:int}", (int id) =>
{
    mdddContext db = new mdddContext();
    var dietas = new DietaColacion { Id = id };
    db.Entry(dietas).State = EntityState.Deleted;
    int k = db.SaveChanges();
    return k == 0 ? Results.Problem() : Results.Ok("Dieta eliminada!");
});

//mostrar dietas e imagenes
app.MapGet("/app/dietas/ver", () =>
{
    mdddContext db = new mdddContext();
    var k = db.DietaColacions.ToList();
    return Results.Ok(k);
});


//mostrar ingredientes
app.MapGet("/app/mostrarIngredientes", () =>
{
    mdddContext db = new mdddContext();
    var lista = db.IngredientesImagens.ToList();
    return Results.Ok(lista);
});

//editar ingrediente por id
app.MapPut("/app/ingre/edit", (IngredientesImagen ingrediente) =>
{
    System.Console.WriteLine(ingrediente.Id);
    mdddContext db = new mdddContext();
    var ingre1 = db.ColacionIngredientes.FirstOrDefault(p => p.Id == ingrediente.Id);
    ingre1.Id = ingre1.Id;
    System.Console.WriteLine(ingre1);
    db.Entry(ingre1).State = EntityState.Modified;
    int element = db.SaveChanges();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});

//editar estado de activo a bloquea y de bloqueado a activo
app.MapPut("/app/actEstado", (Paciente paciente) =>
{
    System.Console.WriteLine(paciente.Rut);
    mdddContext db = new mdddContext();
    //var pacientess = new Paciente {Rut = paciente.Rut};
    var pacientess = db.Pacientes.FirstOrDefault(p => p.Rut == paciente.Rut);
    pacientess.Estado = paciente.Estado;
    System.Console.WriteLine(pacientess);
    db.Entry(pacientess).State = EntityState.Modified;
    int element = db.SaveChanges();
    var lista = db.Pacientes.ToList();
    return Results.Ok(lista);
});

//editar estado de activo a blopqueado de profesional
app.MapPut("/app/actEstado/profesional", (Profesional profesional) =>
{
    System.Console.WriteLine(profesional.Rut);
    mdddContext db = new mdddContext();
    var profesionall = db.Profesionals.FirstOrDefault(p => p.Rut == profesional.Rut);
    profesionall.Estado = profesional.Estado;
    System.Console.WriteLine(profesionall);
    db.Entry(profesionall).State = EntityState.Modified;
    int element = db.SaveChanges();
    var lista = db.Profesionals.ToList();
    return Results.Ok(lista);
});

//add ingre_dieta
app.MapPost("/app/ingrediente0/add", (IngredientesImagen ingrediente) =>
{
    mdddContext db = new mdddContext();
    db.IngredientesImagens.Add(ingrediente);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("ingrediente agregado");
    else
        return Results.Problem();
});


//crear informacion nutricional... tabla ingredientes_dieta
/*app.MapPost("/app/infonutri/add", (ColacionIngrediente infonutri) =>
{
    mdddContext db = new mdddContext();
    db.ColacionIngredientes.Add(infonutri);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("Informacion nutricional agregada");
    else
        return Results.Problem();
});
*/

//eliminar por id, informacion nutricional... tabla ingredientes_dieta
app.MapDelete("/app/infonutri/eliminar/{id:int}", (int id) =>
{
    mdddContext db = new mdddContext();
    var infonutri = new ColacionIngrediente { Id = id };
    db.Entry(infonutri).State = EntityState.Deleted;
    int k = db.SaveChanges();
    return k == 0 ? Results.Problem() : Results.Ok("Informacion Nutricional eliminada!");
});

//editar informacion nutriciconal
/*app.MapPut("/app/infonutri/edit", (ColacionIngrediente infonutri) =>
{
    System.Console.WriteLine(infonutri.Id);
    mdddContext db = new mdddContext();
    var infonutrii = db.ColacionIngredientes.FirstOrDefault(p => p.Id == infonutri.Id);
    infonutrii. = infonutri.Descripcion;
    System.Console.WriteLine(infonutrii);
    db.Entry(infonutrii).State = EntityState.Modified;
    int element = db.SaveChanges();
    var lista = db.ColacionIngredientes.ToList();
    return Results.Ok(lista);
});
*/

//ver infonutri
/*app.MapGet("/app/ver/infonutri", () =>
{
    mdddContext db = new mdddContext();
    var k = db.ColacionIngredientes.ToList();
    return Results.Ok(k);
});
*/


//dietas_colacion
/*app.MapPost("/app/dietas_colacion/add", (DietaColacion dietaColacion) =>
{
    mdddContext db = new mdddContext();
    db.DietaColacions.Add(dietaColacion);
    int n = db.SaveChanges();
    if (n > 0)
        return Results.Accepted("agregado");
    else
        return Results.Problem();
});
*/


//clonar
app.MapPost("/app/add/dieta_copia", (DietaColacion dc) =>
{
    mdddContext db = new mdddContext();
    db.DietaColacions.Add(dc);
    int n = db.SaveChanges();

    int id_original = dc.Id;
    // int id_copia = db.DietaCopia.Id;

    System.Console.WriteLine(id_original);
    var ids = from i in db.ColacionIngredientes
              where i.IdColacion == id_original
              select i;
    // System.Console.WriteLine(ids.Count);
    foreach (var item in ids)
    {
        System.Console.WriteLine(item.Nombre);
    }

    if (n > 0)
        return Results.Accepted("dieta_copia agregada");
    else
        return Results.Problem();
});


//colacion pasar dieta-colacion a un elemnto de c#.
app.MapPost("/app/dieta_colacion1", (Datos dietacolacion) =>
{
    System.Console.WriteLine(dietacolacion.Id);
    System.Console.WriteLine(dietacolacion.PacienteId);
    System.Console.WriteLine(dietacolacion.Nombre);
    System.Console.WriteLine(dietacolacion.TipoVegan);
    System.Console.WriteLine(dietacolacion.TipoComida); //desayuno, almurzo, cena

    foreach (var item in dietacolacion.ingredientes)
    {
        System.Console.WriteLine(item.id);
        System.Console.WriteLine(item.tipo);
        System.Console.WriteLine(item.nombre);
        System.Console.WriteLine(item.cantidad);
        System.Console.WriteLine(item.descripcion);
    }

    //  mdddContext db = new mdddContext();
    int id_dieta = 0;
    using (var db = new mdddContext())
    {
        var dieta = new DietaColacion { Nombre = dietacolacion.Nombre, PacienteId = dietacolacion.PacienteId, TipoVegan = dietacolacion.TipoVegan, TipoComida = dietacolacion.TipoComida };
        db.DietaColacions.Add(dieta);
        int n = db.SaveChanges();
        id_dieta = dieta.Id;
        // System.Console.WriteLine("1..."+id_dieta);
    }
    //dieta copia: tabla

    int id_cc = 0;
    using (var db = new mdddContext())
    {
        //colacion copia: la tabla
        var cc = new Colacion { DietaColacionId = id_dieta, TipoComida = dietacolacion.TipoComida };
        db.Colacions.Add(cc);
        db.SaveChanges();
        id_cc = cc.Id;

    }
    //ingredientes colacion: la tabla
    //for

    using (var db = new mdddContext())
    {
        foreach (var item in dietacolacion.ingredientes)
        {
            var ingrec = new ColacionIngrediente { Nombre = item.descripcion, Cantidad = (item.cantidad).ToString(), Tipo = item.tipo, IdColacion = id_cc, IdIngredientesImagen = item.id };
            db.ColacionIngredientes.Add(ingrec);
            db.SaveChanges();
        }
    }
    return Results.Ok("ok");
});

//aa
app.MapGet("/app/dieta/recupera/{rut}", (string rut) =>
{
    mdddContext db = new mdddContext();
    var k = db.Pacientes.ToList().FirstOrDefault(p => p.Rut == rut).Id;
    System.Console.WriteLine(k);
    return Results.Ok(k);
});

//logica grafico pacientes x enfermedad
app.MapPost("/app/enfermedades/pacientes", (int pacienteId) =>
{
    using (var db = new mdddContext())
    {
        var paciente = db.Pacientes.FirstOrDefault(p => p.Id == pacienteId);
        if (paciente != null)
        {

            var enfermedades = paciente.Descripcion?.Split(',').ToList();
            return enfermedades ?? new List<string>();
        }
        else
        {
            return new List<string>();
        }
    }
});

//prueba, rescatar datos
/*app.MapPut("/app/ingredientes/edit", (ColacionIngrediente colacionIngrediente)=>
{
    {
        System.Console.WriteLine(colacionIngrediente.Id);
        mdddContext db = new mdddContext();
        var ingredientes2 = db.ColacionIngredientes.FirstOrDefault(e => e.Id == colacionIngrediente.Id);
        System.Console.WriteLine(ingredientes2);
        ingredientes2.Tipo = colacionIngrediente.Tipo;
        ingredientes2.Nombre = colacionIngrediente.Nombre;
        ingredientes2.Cantidad = colacionIngrediente.Cantidad.ToString();
        db.Entry(ingredientes2).State = EntityState.Modified;
        int element = db.SaveChanges();
        var kk = db.ColacionIngredientes.ToList();
        return Results.Ok(kk);
    }
});
*/

// consulta entre colacioningrediente, colacion y ingredienteimagen... //
app.MapGet("/app/igredieta/{id}", (int id) =>
{
    using (var context = new mdddContext())
    {
        var resultado = context.Colacions
        .Where(c => c.DietaColacionId == id)
        .SelectMany(c => c.ColacionIngredientes)
        .Select(ci => new
        {
            NombreIngrediente = ci.IdIngredientesImagenNavigation.Nombre,
            Cantidad = ci.Cantidad,
            nombreDescripcion=ci.Nombre,
            TipoIngrediente = ci.IdIngredientesImagenNavigation.Tipo
        })
        .ToList();

        return Results.Ok(resultado);
    }
});


app.Run();