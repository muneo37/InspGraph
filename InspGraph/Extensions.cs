using InspGraph;
using InspGraph.Data;

namespace InspGraph;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<InspectionDataContext>();
#if DEBUG
            context.Database.EnsureDeleted();
#endif
            if (context.Database.EnsureCreated())
            {
                System.Diagnostics.Debug.WriteLine("データベースを初期化します。");
                DbInitializer.Initialize(context);
            }
        }
    }
}
