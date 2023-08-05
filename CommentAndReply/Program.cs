using CommentAndReply;
using CommentAndReply.Contracts;
using CommentAndReply.Repository;
using CommentAndReply.Services;
using CommentAndReply.ViewComponents;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICommentAndReplayServices,CommentAndReplayServices>();
builder.Services.AddScoped<ICommentAndReplyRepository, CommentAndReplyRepository>();
builder.Services.AddDbContext<CommentAndReplyDbcontext>(
    options =>
    {
        options.UseSqlServer("Server=.;Database=CommentAndReply;Trusted_Connection=True;");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
