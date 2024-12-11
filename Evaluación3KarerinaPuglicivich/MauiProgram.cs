using Firebase.Database;
using Microsoft.Extensions.Logging;

namespace Evaluación3KarerinaPuglicivich
{
    public static class MauiProgram
    {
        
        public static FirebaseClient FirebaseClient { get; private set; } = new FirebaseClient("https://registroestudiantes-93cb9-default-rtdb.firebaseio.com/");

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
