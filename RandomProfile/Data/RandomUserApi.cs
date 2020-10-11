using System;

using System.Globalization;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RandomProfileApp.Data
{
    // API: https://randomuser.me/api/?inc=name,email,picture,dob,location

    public partial class RandomUserApi
    {
        public Result[] Results { get; set; }
        public Info Info { get; set; }
    }

    public partial class Info
    {
        public string Seed { get; set; }
        public long Results { get; set; }
        public long Page { get; set; }
        public string Version { get; set; }
    }

    public partial class Result
    {
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public Dob Dob { get; set; }
        public Picture Picture { get; set; }
    }

    public partial class Dob
    {
        public DateTimeOffset Date { get; set; }
        public long Age { get; set; }
    }

    public partial class Location
    {
        public Street Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public Coordinates Coordinates { get; set; }
        public Timezone Timezone { get; set; }
    }

    public partial class Coordinates
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public partial class Street
    {
        public long Number { get; set; }
        public string Name { get; set; }
    }

    public partial class Timezone
    {
        public string Offset { get; set; }
        public string Description { get; set; }
    }

    public partial class Name
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }

    public partial class Picture
    {
        public Uri Large { get; set; }
        public Uri Medium { get; set; }
        public Uri Thumbnail { get; set; }
    }

    public partial class RandomUserApi
    {
        private static IMapper _mapper = default;        

        static RandomUserApi()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<RandomUserApi, RandomProfileApp.Models.Profile>()
            .ForMember(dest => dest.Picture, act => act.MapFrom(src => src.Results[0].Picture.Large))
            .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Results[0].Name.Title))
            .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.Results[0].Name.First))
            .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.Results[0].Name.Last))
            .ForMember(dest => dest.DateOfBirth, act => act.MapFrom(src => src.Results[0].Dob.Date.DateTime))
            .ForMember(dest => dest.Street, act => act.MapFrom(src => src.Results[0].Location.Street.Name))
            .ForMember(dest => dest.StreetNumber, act => act.MapFrom(src => src.Results[0].Location.Street.Number))
            .ForMember(dest => dest.City, act => act.MapFrom(src => src.Results[0].Location.City))
            .ForMember(dest => dest.State, act => act.MapFrom(src => src.Results[0].Location.State))
            .ForMember(dest => dest.Country, act => act.MapFrom(src => src.Results[0].Location.Country))
            .ForMember(dest => dest.PostCode, act => act.MapFrom(src => src.Results[0].Location.Postcode))
            .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Results[0].Email))
            .ForMember(dest => dest.Rating, act => act.MapFrom(src => new Random().Next(6))));

            _mapper = config.CreateMapper();
        }

        public static void FromJson(string json, RandomProfileApp.Models.Profile profile)
        {
            RandomUserApi randomProfile = JsonConvert.DeserializeObject<RandomUserApi>(json, Converter.Settings);            
            _mapper.Map(randomProfile, profile);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}