using FlyFF.API.Models.DTOs;

namespace FlyFF.API.Data;

public static class DB
{
    public static readonly List<ItemDTO> Items = new()
    {
        new ItemDTO() 
        { 
            Name = "Flaris", 
            Description = 
                "Flaris is the continent where vagrants start. " +
                "The strongest Masquerpets that normally appear on this continent are Bangs. " +
                "The town on this continent is named Flarine. " +
                "This town has small houses and vendors selling common items. " +
                "It is often insufficient for a player after their first job change, after which most players move on to Saint  Morning. " +
                "\n\n" +
                "The Mercenary master and the Assist master are located in Flarine, as well as Martyinc and Gergantes. " +
                @"Their National Motto is ""To New Beginnings"" and their National Anthem is ""Ode to To The Sea""." 
        },
        new ItemDTO() 
        { 
            Name = "Saint Morning", 
            Description = 
                "Saint Morning is the continent where 1st Jobs train. " +
                "Saint Morning town center is where markets are set up. " +
                "Trading and private shops are a common sight in Saint Morning. " +
                "Guilds can also be created by talking to Helena. " +
                "\n\n" +
                "Saint Morning is home to many mobs. " +
                @"Their National Motto is ""May Rhisis Guide Your Travels"" and their National Antem is ""Hymn To Heavens""."
        },
        new ItemDTO() 
        { 
            Name = "Garden of Rhisis", 
            Description = 
                "The Garden of Rhisis are the remains of an old Paradise created by the Gods. " +
                "It was a beautiful place, a perfect place, with no pain, hatred, feuds, or greed. " +
                "The people would come here for picnics and such to admire the beautiful gardens created by the gods. " +
                "Once home to the most beautiful gardens the world has ever known. " +
                "The Garden of Rhisis was destroyed in the war with Clockworks, and now all that remains is a graveyard of the once stunning horticultural achievement. " +
                "\n\n" +
                "No one visits the garden anymore, it stands as a symbol of what was once there. " +
                "A graveyard filled with Masquerpets, and a history long forgotten by it's people." 
        },
        new ItemDTO() 
        { 
            Name = "Darkon", 
            Description = 
                "Darkon is by far the largest continent in Madrigal. " +
                "It houses almost all endgame content. " +
                "\n\n" +
                @"Their National Motto is ""Destiny Decides Your Fate"" and their National Anthem is ""Ode To The Guardians""." 
        },
        new ItemDTO() 
        { 
            Name = "Azria", 
            Description = 
                "Azria is a continent where formidable adventurers go. " +
                "The strongest Masquerpets for the Second Job is here. " +
                "\n\n" +
                "There is no town or city here but there was a kingdom here but its was destroyed by Shade." 
        }
    };
}