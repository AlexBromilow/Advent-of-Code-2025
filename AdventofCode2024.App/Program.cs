﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using AdventofCode.Core.PuzzleInput.Service;
using AdventofCode.Core.PuzzleInput.Service.Interface;
using AdventofCode.Core.PuzzleInput.Repository;
using AdventofCode.Core.Puzzle;
using Advent_of_Code_2024.Day1;
using Advent_of_Code_2024.Day2;
using Advent_of_Code_2024.Day3;
using Advent_of_Code_2024.Day4;
using Advent_of_Code_2024.Day5;
using Advent_of_Code_2024.Day6;
using Advent_of_Code_2024.Day7;
using Advent_of_Code_2024.Day8;
using Advent_of_Code_2024.Day9;
using Advent_of_Code_2024.Day10;
using Advent_of_Code_2024.Day11;
using AdventofCode.Core.Shared.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Configuration.AddJsonFile("C:\\Projects\\Advent of Code 2024\\AdventofCode2024.App\\appsettings.json", optional: false, reloadOnChange: true);

        builder.Services.AddSingleton<IPuzzleInputService, PuzzleInputService>();
        builder.Services.AddSingleton<PuzzleInputRepository>();
        builder.Services.AddSingleton<CoordinateService>();
        builder.Services.AddSingleton<Day1>();
        builder.Services.AddSingleton<Day2>();
        builder.Services.AddSingleton<Day3>();
        builder.Services.AddSingleton<Day4>();
        builder.Services.AddSingleton<Day5>();
        builder.Services.AddSingleton<Day6>();
        builder.Services.AddSingleton<Day7>();
        builder.Services.AddSingleton<Day8>();
        builder.Services.AddSingleton<Day9>();
        builder.Services.AddSingleton<Day10>();
        builder.Services.AddSingleton<Day11>();
        builder.Services.AddTransient<PuzzleTools>();

        using IHost host = builder.Build();

        using IServiceScope serviceScope = host.Services.CreateScope();

        IServiceProvider serviceProvider = serviceScope.ServiceProvider;

        Day11 day11 = serviceProvider.GetRequiredService<Day11>();

        day11.Challenge2();

        await host.RunAsync();
    }
}