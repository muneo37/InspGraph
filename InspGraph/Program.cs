using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using InspGraph.ViewModels;
using InspGraph;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<StatisticsViewModel>();

// データベースコンテキストを DI コンテナに登録
builder.Services.AddDbContext<InspectionDataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("InspectionDataContext")));

// EF Core ではナビゲーションプロパティの修復が自動的におこなわれるので、最終的にオブジェクトグラフの循環が生じる可能性があり、この循環を無視するようにしています。
//      Microsoft 公式：https://learn.microsoft.com/ja-jp/ef/core/querying/related-data/serialization
//      個人ブログ：https://nukomabo.work/post-1127/
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// データベース例外フィルターを追加することで Migrations に関するエラー診断ができるようになるらしい。未調査。
// NuGet パッケージ Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore が必要。
//      Microsoft 公式：https://learn.microsoft.com/ja-jp/aspnet/core/data/ef-rp/intro?view=aspnetcore-7.0&tabs=visual-studio#add-the-database-exception-filter
// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// データベースのシードを作成します。
//      EnsureCreated() はデータベースが頻繁に再作成あるいは削除されるようなデバッグ環境を想定している。
//      Microsoft 公式：https://learn.microsoft.com/ja-jp/aspnet/core/data/ef-rp/intro?view=aspnetcore-7.0&tabs=visual-studio&viewFallbackFrom=aspnetcore-2.2#update-main
//      実運用環境では移行履歴テーブルを残しながらデータベースを変更できる Migrations によるデータベース作成が良い。
//      EnsureCreated() で作成したデータベースは Migrations に対応していないため、リリースビルド用には切り替える必要がある。
//      Microsoft 公式：https://learn.microsoft.com/ja-jp/aspnet/core/data/ef-rp/migrations?view=aspnetcore-7.0&tabs=visual-studio
app.CreateDbIfNotExists();

app.Run();
