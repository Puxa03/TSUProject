using Hedgehogs.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Hedgehogs.Persistance.Config
{
    class HedgehogConfiguration : IEntityTypeConfiguration<Hedgehog>
    {
        public void Configure(EntityTypeBuilder<Hedgehog> builder)
        {
            builder.ToTable(nameof(Hedgehog));
            builder.HasKey(hh => hh.Id);
            builder.Property(hh => hh.Name).IsRequired().HasMaxLength(30);
            builder.Property(hh => hh.Radius).IsRequired();
            builder.Property(hh => hh.SpikeCount).IsRequired();
            builder.Property(hh => hh.PictureUrl).IsRequired().HasMaxLength(512);
            builder.Property(hh => hh.Description).HasMaxLength(1024);
            builder.HasData(CreateMyHedgehogs());
        }

        private List<Hedgehog> CreateMyHedgehogs()
        {
            var HedgehogList = new List<Hedgehog>()
            {
                new Hedgehog(){Id=1,Name="Miguel",SpikeCount=4200,Radius=7.61,PictureUrl="https://i.imgur.com/oZMaKdl.png",Description="i float."},
                new Hedgehog(){Id=2,Name="Lalo",SpikeCount=9999,Radius=10,PictureUrl="https://i.imgur.com/AljAtSn.jpeg",Description="Wanted for multiple war crimes in Serbia during the 90s"},
                new Hedgehog(){Id=3,Name="Juan",SpikeCount=3142,Radius=3.14,PictureUrl="https://i.imgur.com/vmz0s3z.jpeg",Description="henlo fren i smol, i also love commiting tax fraud on my free time"},
                new Hedgehog(){Id=4,Name="Antonio",SpikeCount=5023,Radius=20,PictureUrl="https://i.imgur.com/gC7ruMc.jpeg",Description="Should i add you to my menu? Human is my second favourite meal."},
                new Hedgehog(){Id=5,Name="Sonic",SpikeCount=3,Radius=50,PictureUrl="https://i.imgur.com/yqsMMuh.png",Description="Gotta Go Fast"},
                new Hedgehog(){Id=6,Name="José",SpikeCount=2239,Radius=2,PictureUrl="https://i.imgur.com/PKqN5gl.jpeg",Description="I share wisdom with puny mortals. The sky is blue, Miguel Floats, If you are Bosnian avoid Lalo At all costs and you may not want to cross Antonio in General... There were more of us until he arrived.. Not even Pablo could escape him."},
                new Hedgehog(){Id=7,Name="Franco",SpikeCount=6053,Radius=7.7,PictureUrl="https://i.imgur.com/4HeZJTE.jpeg",Description="heh? José and wisdom? nice one. He has lost his mind after that Pablo incident and thinks he is an immortal being or something.Anyways listen to me carefully bud, there's only one true wisdom:you either a smart fella or a fart smella."},
            };
            return HedgehogList;
        }
    }
}
