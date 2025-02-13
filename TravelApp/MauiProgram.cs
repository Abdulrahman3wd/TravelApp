﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration;
namespace TravelApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {



            #if ANDROID
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUndeline", (h, v) =>
            {
                h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
            });
            #endif



            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("BarlowBold.otf" , "BarlowBold");
                    fonts.AddFont("BarlowMedium.otf", "BarlowMedium");
                    fonts.AddFont("BarlowRegular.otf", "BarlowRegular");
                    fonts.AddFont("BarlowSemiBold.otf", "BarlowSemiBold");

                }).ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                    handlers.AddHandler(typeof(Shell), typeof(Platforms.Android.CustomeShellRender));

#endif
                });






#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
