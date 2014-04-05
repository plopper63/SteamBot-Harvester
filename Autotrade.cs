using SteamKit2;
using System.Collections.Generic;
using SteamTrade;
using System;
using System.Threading;

namespace SteamBot
{
    public class Autotrade : UserHandler
    {
        public int ScrapPutUp;
        public int curBot = 1;
        public bool isCollecting = false;

        public Autotrade (Bot bot, SteamID sid) : base(bot, sid) {}

        public override bool OnGroupAdd()
        {
            return false;
        }

        public override bool OnFriendAdd () 
        {
            return true;
        }

        public override void OnLoginCompleted()
        {
            
        }


        public override void OnChatRoomMessage(SteamID chatID, SteamID sender, string message)
        {
            Log.Info(Bot.SteamFriends.GetFriendPersonaName(sender) + ": " + message);
            base.OnChatRoomMessage(chatID, sender, message);
        }

        public override void OnFriendRemove () {}
        
        public override void OnMessage (string message, EChatEntryType type) 
        {
            if (message == ".help")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "----------------------------");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, ".delete_crates");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Deletes crates");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "----------------------------");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, ".ready");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Sets current trade to ready");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "----------------------------");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, ".craft_all");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Combines all weps into scrap");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "----------------------------");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, ".craft_scrap");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Combines all scrap into rec");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "----------------------------");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, ".craft_rec");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Combines all rec into ref");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "----------------------------");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, ".[##]");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Sends trade rqst to bot_##");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "----------------------------");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, ".harvest");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "delete crates & craft allin1");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "----------------------------");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, ".help");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Gets back to this menu");
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "----------------------------");
            }
            if (message == ".delete_crates")
            {
                Bot.DeleteAllCrates();
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Removing all crates...");
            }
            
            // ============================================================
            // YOU HAVE TO SEND THE .READY MESSAGE IN ORDER TO ACCEPT TRADE
            // OTHERWISE, THE PROGRAM WILL CRASH, AND THE SPACE WHALES WILL
            // BE VERY SAD FOR YOU. :c
            // https://www.youtube.com/watch?v=60BjkUtqxPE
            // =============================================================
            
            if (message == ".ready")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Setting current trade to 'Ready.'");
                Trade.SetReady(true);
                Trade.AcceptTrade();
            }
            if (message == ".craft_all")
            {
                Bot.AutoCraftAllWeps();
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Crafting Weapons together...");
            }
            if (message == ".craft_scrap")
            {
                Bot.AutoCraftAllScrap();
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Crafting Scrap together...");
            }
            if (message == ".craft_rec")
            {
                Bot.AutoCraftAllRec();
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Crafting Rec together...");
            }
            if (message == ".collect")
            {
                isCollecting = true;
            }

            // ====================================
            // Account management messages
            // ====================================

            if (message == ".2")
            {
                Bot.OpenTrade(76561198085193875);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 02_BlockCat.");
            }
            if (message == ".3")
            {
                Bot.OpenTrade(76561198087057186);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 03_BlockCat.");
            }
            if (message == ".4")
            {
                Bot.OpenTrade(76561198087040798);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 04_BlockCat.");
            }
            if (message == ".5")
            {
                Bot.OpenTrade(76561198088692004);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 05_BlockCat.");
            }
            if (message == ".6")
            {
                Bot.OpenTrade(76561198088668067);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 06_BlockCat.");
            }
            if (message == ".7")
            {
                Bot.OpenTrade(76561198088602888);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 07_BlockCat.");
            }
            if (message == ".8")
            {
                Bot.OpenTrade(76561198088763100);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 08_BlockCat.");
            }
            if (message == ".9")
            {
                Bot.OpenTrade(76561198090501272);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 09_BlockCat.");
            }
            if (message == ".10")
            {
                Bot.OpenTrade(76561198091584568);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 10_BlockCat.");
            }
            if (message == ".11")
            {
                Bot.OpenTrade(76561198091600692);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 11_BlockCat.");
            }
            if (message == ".12")
            {
                Bot.OpenTrade(76561198091791084);
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 12_BlockCat.");
            }
            if (message == ".13")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 13_BlockCat.");
                Bot.OpenTrade(76561198091815269);
            }
            if (message == ".14")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 14_BlockCat.");
                Bot.OpenTrade(76561198091685299);
            }
            if (message == ".15")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 15_BlockCat.");
                Bot.OpenTrade(76561198091668065);
            }
            if (message == ".16")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 16_BlockCat.");
                Bot.OpenTrade(76561198091697087);
            }
            if (message == ".17")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 17_BlockCat.");
                Bot.OpenTrade(76561198091834884);
            }
            if (message == ".18")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 18_BlockCat.");
                Bot.OpenTrade(76561198091843128);
            }
            if (message == ".19")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 19_BlockCat.");
                Bot.OpenTrade(76561198091856477);
            }
            if (message == ".20")
            {
                Bot.SteamFriends.SendChatMessage(OtherSID, EChatEntryType.ChatMsg, "Starting trade with: 20_BlockCat.");
                Bot.OpenTrade(76561198108365089);
            }
       
            Bot.SteamFriends.SendChatMessage(OtherSID, type, Bot.ChatResponse);
        }

        public override bool OnTradeRequest() 
        {
            return true;
        }
        
        public override void OnTradeError (string error) 
        {
            Bot.SteamFriends.SendChatMessage (OtherSID, 
                                              EChatEntryType.ChatMsg,
                                              "Oh, there was an error: " + error + "."
                                              );
            Bot.log.Warn (error);
        }
        
        public override void OnTradeTimeout () 
        {
            Bot.SteamFriends.SendChatMessage (OtherSID, EChatEntryType.ChatMsg,
                                              "Sorry, but you were AFK and the trade was canceled.");
            Bot.log.Info ("User was kicked because he was AFK.");
        }
        
        public override void OnTradeInit() 
        {
            
            if (isCollecting)
            {
                Bot.log.Error("-------------------------------");
                Bot.log.Error("[       Auto-adding items      ]");
                Bot.log.Error("-------------------------------");
                for (int i = 1; i <= 9999; i++)
                {
                    if (i == 9999)
                    {
                        break;
                    }
                    Trade.AddAllItemsByDefindex(i);

                }
            }
            else
            {
                Bot.log.Error("-------------------------------");
                Bot.log.Error("[       Catching items.       ]");
                Bot.log.Error("-------------------------------");
            }
            
        }
        
        public override void OnTradeAddItem (Schema.Item schemaItem, Inventory.Item inventoryItem) 
        {
            var item = Trade.CurrentSchema.GetItem(schemaItem.Defindex);
            Bot.log.Success("User added: " + schemaItem.Name);
        }
        
        public override void OnTradeRemoveItem (Schema.Item schemaItem, Inventory.Item inventoryItem) {}
        
        public override void OnTradeMessage (string message) {}
        
        public override void OnTradeReady (bool ready) 
        {
            if (!ready)
            {
                Trade.SetReady (false);
                try
                {
                    if (Trade.AcceptTrade())
                        Log.Success("Trade Accepted!");
                }
                catch
                {
                    Log.Warn("The trade might have failed, but we can't be sure.");
                }
            }
            else
            {
                Trade.SetReady (true);
                Trade.SendMessage ("Finished adding all items!");
                try
                {
                    if (Trade.AcceptTrade())
                        Log.Success("Trade Accepted!");
                }
                catch
                {
                    Log.Warn("The trade might have failed, but we can't be sure.");
                }
            }
        }

        public override void OnTradeSuccess()
        {
            // Trade completed successfully
            Log.Success("Trade Complete.");

        }

        public override void OnTradeAccept() 
        {
            if (Validate() || IsAdmin)
            {
                //Even if it is successful, AcceptTrade can fail on
                //trades with a lot of items so we use a try-catch
                try {
                    if (Trade.AcceptTrade())
                        Log.Success("Trade Accepted!");
                }
                catch {
                    Log.Warn ("The trade might have failed, but we can't be sure.");
                }
            }

            OnTradeClose ();
        }

        public bool Validate ()
        {            
            ScrapPutUp = 0;
            
            List<string> errors = new List<string> ();
            
            /*foreach (ulong id in Trade.OtherOfferedItems)
            {
                var item = Trade.OtherInventory.GetItem (id);
                if (item.Defindex == 5000)
                    ScrapPutUp++;
                else if (item.Defindex == 5001)
                    ScrapPutUp += 3;
                else if (item.Defindex == 5002)
                    ScrapPutUp += 9;
                else
                {
                    var schemaItem = Trade.CurrentSchema.GetItem (item.Defindex);
                    errors.Add ("Item " + schemaItem.Name + " is not a metal.");
                }
            }
            
            if (ScrapPutUp < 1)
            {
                errors.Add ("You must put up at least 1 scrap.");
            }
            
            // send the errors
            if (errors.Count != 0)
                Trade.SendMessage("There were errors in your trade: ");
            foreach (string error in errors)
            {
                Trade.SendMessage(error);
            }*/
            
            return errors.Count == 0;
        }
        
    }
 
}

