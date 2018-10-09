using System;
using System.Collections.Generic;
using System.IO;
using Models.DbSeed;
using Models.Entity;
using Newtonsoft.Json;
using Repositories.Implementations;

namespace Repositories
{
    public class SeedRepository : ISeedRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        private string tapesSource = "../Repositories/Data/SC-T-302-HONN 2018_ Videotapes.json";
        private string friendsSource = "../Repositories/Data/SC-T-302-HONN 2018_ Friends.json";

        public SeedRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public void SeedDataBase()
        {
            
            try
            {
                using (StreamReader reader = new StreamReader(tapesSource))
                {
                    string json = reader.ReadToEnd();
                    List<SeedVideoTapes> tapes = JsonConvert.DeserializeObject<List<SeedVideoTapes>>(json);
                    
                    //for each tape we create a new TapeEntity
                    foreach (SeedVideoTapes tape in tapes)
                    {
                        Tape newVideoTape = new Tape
                        {
                            Id = tape.id,
                            Title = tape.title,
                            DirectorName = tape.director_first_name + " " + tape.director_last_name,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            Eidr = tape.eidr,
                            ReleaseDate = tape.release_date,
                            Type = tape.type
                                
                        };
                        _dataBaseContext.Tapes.Add(newVideoTape);
                    }

                    try
                    {
                        _dataBaseContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            try
            {
                using (StreamReader streamReader = new StreamReader(friendsSource))
                {
                    string strjson = streamReader.ReadToEnd();
                    //List<SeedVideoTapes> tapes = JsonConvert.DeserializeObject<List<SeedVideoTapes>>(json);
                    List<SeedFriends> friends = JsonConvert.DeserializeObject<List<SeedFriends>>(strjson);
                    
                    // loop all friends and insert to Friend entity model also insert Borrow info to Borrow entity model
                    foreach (SeedFriends friend in friends)
                    {
                        Friend newfriend = new Friend
                        {
                            Id = friend.id,
                            Address = friend.address,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            Email = friend.email,
                            Name = friend.first_name + " " + friend.last_name,
                            Phone = friend.phone
                        };
                        _dataBaseContext.Add(newfriend);    
                        
                        if (friend.tapes != null)
                        {
                            foreach (SeedBorrowedTapes borrow in friend.tapes)
                            {
                                Borrow newBorrow = new Borrow
                                {
                                    FriendId = friend.id,
                                    TapeId = borrow.id,
                                    BorrowDate = borrow.borrow_date,
                                    ReturnDate = null
                                };
                                _dataBaseContext.Add(newBorrow);
                            }
                        }
                        
                    }

                    try
                    {
                        _dataBaseContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }

        public void SeedTapes()
        {
        }

    }
}