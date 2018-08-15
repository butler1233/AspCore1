using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspCore1.Models
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //Set up the context
            using (var cont = new DownloadContext(serviceProvider.GetRequiredService<DbContextOptions<DownloadContext>>()))
            {
                //Check if w've already added any
                if (cont.Download.Any())
                {
                    return; //Already seeded, so no point in reseeding.
                }

                cont.Download.AddRange(
                    new Download
                    {
                        File = "AutoClicker.exe",
                        Modified = DateTime.Parse("2018-07-13 20:36"),
                        SizeKb = 765,
                        ProductName = "Auto Clicker"
                    },
                    new Download
                    {
                        File = "blender-2.79-windows64.exe ",
                        Modified = DateTime.Parse("2017-09-17 00:34"),
                        SizeKb = 85841,
                        ProductName = "Blender 2.79 for Windows x64 "
                    },
                    new Download
                    {
                        File = "bootstrap-4.0.0.zip",
                        Modified = DateTime.Parse("2018-02-13 16:51"),
                        SizeKb = 0,
                        ProductName = "Bootstrap framework 4.0.0 "
                    },
                    new Download
                    {
                        File = "CINEBENCHR15.038.zip ",
                        Modified = DateTime.Parse("2017-09-22 11:35"),
                        SizeKb = 83903,
                        ProductName = "Cinebench R15.038 "
                    },
                    new Download
                    {
                        File = "JetBrains.ReSharperUltimate.2018.1.4.exe",
                        Modified = DateTime.Parse("2018-08-03 10:24"),
                        SizeKb = 182117,
                        ProductName = "ReSharper Ultimate 2018.1.4"
                    },
                    new Download
                    {
                        File = "SpotifySetup.exe",
                        Modified = DateTime.Parse("2017-09-04 22:35"),
                        SizeKb = 661,
                        ProductName = "Spotify Installer"
                    }
                );
                cont.SaveChanges();
            }
        }
    }
}
