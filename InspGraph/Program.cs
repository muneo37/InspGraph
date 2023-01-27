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

// �f�[�^�x�[�X�R���e�L�X�g�� DI �R���e�i�ɓo�^
builder.Services.AddDbContext<InspectionDataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("InspectionDataContext")));

// EF Core �ł̓i�r�Q�[�V�����v���p�e�B�̏C���������I�ɂ����Ȃ���̂ŁA�ŏI�I�ɃI�u�W�F�N�g�O���t�̏z��������\��������A���̏z�𖳎�����悤�ɂ��Ă��܂��B
//      Microsoft �����Fhttps://learn.microsoft.com/ja-jp/ef/core/querying/related-data/serialization
//      �l�u���O�Fhttps://nukomabo.work/post-1127/
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// �f�[�^�x�[�X��O�t�B���^�[��ǉ����邱�Ƃ� Migrations �Ɋւ���G���[�f�f���ł���悤�ɂȂ�炵���B�������B
// NuGet �p�b�P�[�W Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore ���K�v�B
//      Microsoft �����Fhttps://learn.microsoft.com/ja-jp/aspnet/core/data/ef-rp/intro?view=aspnetcore-7.0&tabs=visual-studio#add-the-database-exception-filter
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

// �f�[�^�x�[�X�̃V�[�h���쐬���܂��B
//      EnsureCreated() �̓f�[�^�x�[�X���p�ɂɍč쐬���邢�͍폜�����悤�ȃf�o�b�O����z�肵�Ă���B
//      Microsoft �����Fhttps://learn.microsoft.com/ja-jp/aspnet/core/data/ef-rp/intro?view=aspnetcore-7.0&tabs=visual-studio&viewFallbackFrom=aspnetcore-2.2#update-main
//      ���^�p���ł͈ڍs�����e�[�u�����c���Ȃ���f�[�^�x�[�X��ύX�ł��� Migrations �ɂ��f�[�^�x�[�X�쐬���ǂ��B
//      EnsureCreated() �ō쐬�����f�[�^�x�[�X�� Migrations �ɑΉ����Ă��Ȃ����߁A�����[�X�r���h�p�ɂ͐؂�ւ���K�v������B
//      Microsoft �����Fhttps://learn.microsoft.com/ja-jp/aspnet/core/data/ef-rp/migrations?view=aspnetcore-7.0&tabs=visual-studio
app.CreateDbIfNotExists();

app.Run();
