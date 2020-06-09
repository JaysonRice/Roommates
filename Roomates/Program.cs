﻿using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);
            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);


            ///  Show the room with Id of 1.
            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 1");

            Room singleRoom = roomRepo.GetById(1);

            Console.WriteLine($"{singleRoom.Id} {singleRoom.Name} {singleRoom.MaxOccupancy}");

            ///  Create a new room known as Bathroom with a Max Occupancy of 1.
            Room bathroom = new Room
            {
                Name = "Bathroom",
                MaxOccupancy = 1
            };

            roomRepo.Insert(bathroom);

            //Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id}");

            Room updatedBathroom = new Room
            {
                Name = "Pool Room",
                MaxOccupancy = 40,
                Id = bathroom.Id
            };

            roomRepo.Update(updatedBathroom);

            Console.WriteLine("-------------------------------");

            Console.WriteLine($"Deleting the new Room with id {bathroom.Id}");
            roomRepo.Delete(bathroom.Id);


            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Room> allRooms = roomRepo.GetAll();

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }


            Console.WriteLine("Getting All Roommates:");
            Console.WriteLine();

            List<Roommate> allRoommates = roommateRepo.GetAll();

            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.Id} {roommate.FirstName} {roommate.LastName} {roommate.RentPortion} {roommate.MoveInDate} {roommate.Room}");
            }

            Console.WriteLine($"Getting All Roommates with id 1:");
            Console.WriteLine();

            Roommate singleRoommate = roommateRepo.GetById(1);

            Console.WriteLine($"{singleRoommate.Id} {singleRoommate.FirstName} {singleRoommate.RentPortion} {singleRoommate.MoveInDate} {singleRoommate.Room}");

            List<Roommate> someRoommates = roommateRepo.GetAllWithRoom(1);

            foreach (Roommate roommate in someRoommates)
            {
                Console.WriteLine($"{roommate.FirstName} {roommate.Room.Name}");
            }

           
        }
    }
}