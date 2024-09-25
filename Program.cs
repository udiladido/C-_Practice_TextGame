using System.Collections.Generic;
using System.Diagnostics;
using TextGame;




namespace TextGame
{

    interface ILoadSave
    {

        void SaveLoad();
        void Save();
    
    }


    public enum ItemPart { 무기, 방어구, 모자, 신발 }

    public enum Itemequip { 착용, 미착용 };

    public enum ItemHav { 소유, 미소유 }

    public class PlayerInfo : ILoadSave
    {

        public String SaveFile = @"SaveInfo.txt";
        public static String PlayerName;
        public static String PlayerClass;
        public static int LV;
        public static int STR;
        public static int DEF;
        public static int HP;
        public static int Gold;

        public static int WeaponStat;
        public static int AmorStat;


        public void Init()
        {

            LV = 1;
            STR = 10; 
            DEF = 5; 
            HP = 100;
            Gold = 1500;
        
        }

        public void SaveLoad()
        {

            StreamReader sr = new StreamReader(SaveFile);

            String Input = sr.ReadToEnd();

            String[] number = Input.Split(' ');

            PlayerName = number[0];
            LV = int.Parse(number[1]);
            PlayerClass = number[2];
            STR = int.Parse(number[3]);
            DEF = int.Parse(number[4]);
            HP = int.Parse(number[5]);
            Gold = int.Parse(number[6]);

        }

        public void Save()
        {

            using (StreamWriter Gameinit = File.CreateText(SaveFile))
            {
                Gameinit.WriteLine($"{PlayerName} {LV} {PlayerClass} {STR} {DEF} {HP} {Gold}");

            }

        }
     

    }
    

    public class ItemInfo
    {
        public String ItemSave = @"PlayerInventory.txt";



        public Itemequip ItemWear { get; set; }
        public String Name { get; set; }
        public ItemPart Part { get; set; }
        public int ItemStat { get; set; }
        public String Info { get; set; }
        public int Cost { get; set; }
        public ItemHav IsBuy { get; set; }


        public ItemInfo(Itemequip itemwear, String name, ItemPart part, int itemstat, String info, int cost, ItemHav isbuy)
        {
            ItemWear = itemwear;
            Name = name;
            Part = part;
            ItemStat = itemstat;
            Info = info;
            Cost = cost;
            IsBuy = isbuy;

        }

        public void SaveLoad() 
        { 
        
        
        }
        public void Save() 
        { 
        
        
        }


    }


    public class Item_List
    {
        public static List<ItemInfo> items = new List<ItemInfo>
        {
            new ItemInfo(Itemequip.미착용, "깃털달린 장화", ItemPart.신발, 3, "깃털이 달려 가벼움을 자랑하며 발소리가 안나 도둑들이 자주 애용한다는 이야기가 있다.", 230, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "철갑 부츠", ItemPart.신발, 8, "무거운 철로 만들어져 방어력은 뛰어나지만 움직임이 둔해진다.", 450, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "바람의 신발", ItemPart.신발, 6, "바람의 힘을 빌려 착용자의 이동 속도를 높여준다.", 780, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "용암의 검", ItemPart.무기, 9, "용암으로 만들어진 검으로, 적을 베면 화상 데미지를 추가로 입힌다.", 890, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "황금 활", ItemPart.무기, 8, "황금으로 만들어진 활로, 화살이 적을 관통하는 특수한 능력이 있다.", 670, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "천둥의 망치", ItemPart.무기, 10, "내리치면 천둥 소리와 함께 번개가 내리쳐 광역 공격이 가능하다.", 920, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "그림자 두건", ItemPart.모자, 4, "얼굴을 가려주어 은신 능력을 높여주고 적의 시선을 끌지 않는다.", 340, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "용기의 투구", ItemPart.모자, 9, "착용자에게 강한 용기를 불어넣어 공포 저항력을 높여준다.", 920, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "지혜의 왕관", ItemPart.모자, 7, "착용자의 지능과 마력을 높여주는 신비한 왕관이다.", 750, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "용의 비늘 갑옷", ItemPart.방어구, 10, "용의 비늘로 만들어져 물리 공격과 마법 공격 모두에 강한 저항력을 지닌다.", 980, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "그림자 망토", ItemPart.방어구, 5, "어둠 속에서 착용자를 완벽히 감추어 은신 능력을 극대화한다.", 500, ItemHav.미소유),
            new ItemInfo(Itemequip.미착용, "요정의 로브", ItemPart.방어구, 6, "가볍고 부드러운 소재로 만들어져 마법 저항력이 높고 움직임이 자유롭다.", 630, ItemHav.미소유)
        };

        
        public List<ItemInfo> InventoryItem;
        public Screen_Page returnScreen = new Screen_Page();

    }


    public class Game_item: Item_List
    {

        public virtual void infoOutPut(bool ItenNum)
        {

            int index = 1;

            foreach (ItemInfo ItemList in items)
            {
                Console.WriteLine($"- {(ItenNum ? index + " " : null)}{ItemList.Name} | {(ItemList.Part == ItemPart.무기 ? "공격력" : "방어력") + ItemList.ItemStat} | {ItemList.Info}");

             
            }

        }

        public virtual void infoOutPut()
        {
            foreach (ItemInfo ItemList in items)
            {
                Console.WriteLine($"- {ItemList.Name} | {(ItemList.Part == ItemPart.무기 ? "공격력" : "방어력") + ItemList.ItemStat} | {ItemList.Info}");


            }

        }


    };


 
    public class Inv_Item : Game_item
    {

        public Dictionary<ItemPart, int> EquipPart = new Dictionary<ItemPart, int>()
        {

        {ItemPart.무기, 0},
        { ItemPart.방어구, 0},
        {ItemPart.모자 , 0},
        { ItemPart.신발, 0}

        };


   
        public void ItemWearing(int ItemNum)
        {


            if (ItemNum > InventoryItem.Count || ItemNum < 0)
            {

                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine("===============");

                returnScreen.Inventory_Page();
            }

            string itemName = InventoryItem[ItemNum - 1].Name;
            int itemNum = items.FindIndex(name => name.Name == $"{itemName}");



            // 장비 부위가 착용하고 있는 경우
            if (items[itemNum].ItemWear == Itemequip.착용 && EquipPart[items[itemNum].Part] == 1)
            {
               
                
                items[itemNum].ItemWear = Itemequip.미착용;
                EquipPart[items[itemNum].Part] = 0;


                switch (items[itemNum].Part)
                {
                    case ItemPart.무기:
                        PlayerInfo.WeaponStat -= items[itemNum].ItemStat;
                        break;
                    default:
                        PlayerInfo.AmorStat -= items[itemNum].ItemStat;
                        break;

                }


                // 돌아가기 Console.WriteLine("장비를 해제합니다.");

                Console.Clear();
                Screen_Page.isItemNum = false;
                returnScreen.Inventory_Page();
                

            }

            //장비 부위가 미착용이지만, 중복인 경우
            else if (items[itemNum].ItemWear == Itemequip.미착용 && EquipPart[items[itemNum].Part] == 1)
            {


                //돌아가기
                Console.Clear();
                Console.WriteLine("해당 부위에 아이템이 이미 존재합니다. 해당 부위 아이템을 헤제하고 다시 시도하세요.");
                Console.WriteLine("==================");

                returnScreen.Inventory_Page();

                

            }

            //장비 부위가 착용하지 않고 중복이 아닌 경우
            else if (items[itemNum].ItemWear == Itemequip.미착용 && EquipPart[items[itemNum].Part] == 0)
            {

                items[itemNum].ItemWear = Itemequip.착용;
                EquipPart[items[itemNum].Part] = 1;


                switch (items[itemNum].Part)
                {

                    case ItemPart.무기:
                        PlayerInfo.WeaponStat += items[itemNum].ItemStat;
                        break;
                    default:
                        PlayerInfo.AmorStat += items[itemNum].ItemStat;
                        break;
                    
                }



                //돌아가기 -  Console.WriteLine("장비를 장착합니다.");

                Console.Clear();
                Screen_Page.isItemNum = false;
                returnScreen.Inventory_Page();

              

            }


        }


        public override void infoOutPut(bool ItenNum)
        {

            InventoryItem = items.FindAll(items => items.IsBuy == ItemHav.소유);

            int index = 1;

            foreach (ItemInfo HasItem in InventoryItem)
            {
                Console.WriteLine($"- {(ItenNum ? index + " " : null)}{(HasItem.ItemWear == Itemequip.착용 ? "[E]" : null)}{HasItem.Name} | {(HasItem.Part == ItemPart.무기 ? "공격력" : "방어력")} + {HasItem.ItemStat} | {HasItem.Info}");

                if (HasItem.ItemWear == Itemequip.착용)
                    EquipPart[HasItem.Part] = 1;

                index++;
            }



        }

        public override void infoOutPut()
        {
            InventoryItem = items.FindAll(items => items.IsBuy == ItemHav.소유);

            foreach (ItemInfo ItemList in InventoryItem)
            {
                Console.WriteLine($"- {(ItemList.ItemWear == Itemequip.착용 ? "[E]" : null)} {ItemList.Name} | {(ItemList.Part == ItemPart.무기 ? "공격력" : "방어력") + ItemList.ItemStat} | {ItemList.Info}");

            }

        }


    }



    public class ShopItem : Game_item
    {




        public override void infoOutPut()
        {

            int index = 1;

            foreach (ItemInfo shopList in items)
            {
                Console.WriteLine($"- {shopList.Name} | {(shopList.Part == ItemPart.무기 ? "공격력" : "방어력") + shopList.ItemStat} | {shopList.Info} |  {(shopList.IsBuy == ItemHav.미소유 ? shopList.Cost : "구매완료")} ");

                index++;
            }

        }


        public override void infoOutPut(bool ItemNum)
        {

            int index = 1;

            foreach (ItemInfo shopList in items)
            {
                Console.WriteLine($"- {(ItemNum ?  index + " ": null)}{shopList.Name} | {(shopList.Part == ItemPart.무기 ? "공격력" : "방어력") + shopList.ItemStat} | {shopList.Info} |  {(shopList.IsBuy == ItemHav.미소유 ? shopList.Cost : "구매완료")} ");

                index++;
            }


        }

        public void BuyItem(int ItemNum)
        {


            if (ItemNum > items.Count || ItemNum < 0)
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine("===============");
                returnScreen.store_Page();

            }


            if (items[ItemNum - 1].IsBuy == ItemHav.소유)
            {
                Console.Clear();
                Console.WriteLine("이미 소유하고 있는 아이템입니다.");
                Console.WriteLine("===============");

                Screen_Page.isItemNum = false;
                returnScreen.store_Page();
            }

            else if (items[ItemNum].Cost < PlayerInfo.Gold)
            {
                Console.Clear();
                Console.WriteLine("구매를 완료했습니다");

                Screen_Page.isItemNum = false;

                items[ItemNum - 1].IsBuy = ItemHav.소유;
                PlayerInfo.Gold -= items[ItemNum - 1].Cost;
                returnScreen.store_Page();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Gold가 부족합니다.");
                Console.WriteLine("===============");

                Screen_Page.isItemNum = false;

                returnScreen.store_Page();
            }
            
        }

    }


    public class Screen_Page()
    {
        public static bool isSelect = false;
        public static bool isItemNum = false;


        public void GameLoad()
        {

            PlayerInfo playinfo = new PlayerInfo();

            if (!File.Exists(playinfo.SaveFile))
            {

                Console.WriteLine("당신의 이름은?");
                String PlayerName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(PlayerName))
                {
                    Console.WriteLine("다시 입력하세요");
                    PlayerName = Console.ReadLine();
                }



                PlayerInfo.PlayerName = PlayerName;

                Console.WriteLine("직업을 선택하세요");
                Console.WriteLine("1. 마법사\n2. 전사\n3. 궁수");

                while (!isSelect)
                {
                    String Choice = Console.ReadLine();

                    switch (Choice)
                    {
                        case "1":
                            isSelect = true;
                            PlayerInfo.PlayerClass = "마법사";
                            break;
                        case "2":
                            isSelect = true;
                            PlayerInfo.PlayerClass = "전사";
                            break;
                        case "3":
                            isSelect = true;
                            PlayerInfo.PlayerClass = "궁수";
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 선택하세요");
                            break;
                    }

                }

                isSelect = false;
                playinfo.Init();
                playinfo.Save();

            }


            else
                playinfo.SaveLoad();

         
            Console.WriteLine($" -- 에 오신 {PlayerInfo.PlayerName}님 환영합니다.");
            Select_Page();
        }



        public void PlayerStat_Page()
        {

            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("=============================");
            Console.WriteLine($"이름 : {PlayerInfo.PlayerName}");
            Console.WriteLine($"LV. {PlayerInfo.LV}");
            Console.WriteLine($"Chad. {PlayerInfo.PlayerClass}");
            Console.WriteLine($"공격력 : {PlayerInfo.STR + PlayerInfo.WeaponStat} ({PlayerInfo.STR} + {PlayerInfo.WeaponStat})");
            Console.WriteLine($"방어력 : {PlayerInfo.DEF + PlayerInfo.AmorStat} ( {PlayerInfo.DEF} + {PlayerInfo.AmorStat})");
            Console.WriteLine($"체력 : {PlayerInfo.HP}");
            Console.WriteLine($"Gold : {PlayerInfo.Gold}G");
            Console.WriteLine("===============================");

            Console.WriteLine("0 : 나가기");

            String ReturnMain = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(ReturnMain) || ReturnMain != "0")
            {
                Console.WriteLine("다시 입력하세요");
                ReturnMain = Console.ReadLine();
            }


            if (ReturnMain == "0")
            {
                Console.Clear();
                Select_Page();
            }

        }



        public void Select_Page()
        {

            Console.WriteLine("======================");
            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전입장\n5. 휴식하기");

            Console.WriteLine("원하시는 행동을 입력하세요");

            Console.WriteLine("======================");
            while (!isSelect)
            {
                String Select = Console.ReadLine();

                switch (Select)
                {
                    case "1":
                        Console.Clear();
                        PlayerStat_Page();
                        isSelect = true;
                        break;
                    case "2":
                        Console.Clear();
                        Inventory_Page();
                        isSelect = true;
                        break;
                    case "3":
                        Console.Clear();
                        store_Page();
                        isSelect = true;
                        break;
                    case "4":
                        Console.Clear();
                        Dungeon_Page();
                        isSelect = true;
                        break;
                    case "5":
                        Console.Clear();
                        Rest_Page();
                        isSelect = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력하세요");
                        break;

                }
            }

            isSelect = false;
        }


        public void Inventory_Page()
        {
            Console.WriteLine($"인벤토리{(isItemNum ? "- 장착 관리" : null)}");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("================");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("================");

            var Inventory_Chk = new Inv_Item();
            Inventory_Chk.infoOutPut(isItemNum);

            Console.WriteLine("=================");
            Console.WriteLine($"{(isItemNum ? null : "1. 장착 관리\n")}0. 나가기");

            if (!isItemNum)
            {

                while (!isSelect)
                {
                    String Select = Console.ReadLine();

                    switch (Select)
                    {
                        case "1":
                            Console.Clear();  
                            isItemNum = true;
                            Inventory_Page();

                            isSelect = true;
                            break;
                        case "0":
                            Console.Clear();
                            isItemNum = false;
                            Select_Page();
                            isSelect = true;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 입력하세요");
                            break;

                    }

                }
                isItemNum = false;
                isSelect = false;
            }
            else
            {
                while (!isSelect)
                {
                    String Select = Console.ReadLine();

                    int ItemNum = int.Parse(Select);

                    switch (ItemNum)
                    {

                        case 0:
                            Console.Clear();
                            isItemNum = false;
                            Select_Page();
                            isSelect = true;
                            break;
                        default:
                            Inventory_Chk.ItemWearing(ItemNum);
                            isSelect = true;
                            break;

                    }

                }
                isItemNum = false;
                isSelect = false;
            }




            isSelect = false;
            isItemNum = false;
        }


        public void store_Page()
        {

            Console.WriteLine($"상점 {(isItemNum ? "- 아이템 구매" : null)}");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("================");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", PlayerInfo.Gold);
            Console.WriteLine("================");

            Console.WriteLine("아이템 목록");

            Console.WriteLine("================");

            var ShopList_Chk = new ShopItem();
            ShopList_Chk.infoOutPut(isItemNum);

            Console.WriteLine("================");
            Console.WriteLine($"{(isItemNum ? null : "1. 아이템 구매\n")}0. 나가기");
            Console.WriteLine("원하시는 행동을 입력하세요");
            if (!isItemNum)
            {
                while (!isSelect)
                {
                    String Select = Console.ReadLine();

                    switch (Select)
                    {
                        case "1":
                            Console.Clear();

                            isItemNum = true;
                            store_Page();

                            isSelect = true;
                            break;
                        case "0":
                            Console.Clear();

                            isItemNum = false;
                            Select_Page();
                            isSelect = true;
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 입력하세요");
                            break;

                    }

                }
                isSelect = false;
                isItemNum = false;
            }
            else
            {
                while (!isSelect)
                {
                    String Select = Console.ReadLine();

                    int ItemNum = int.Parse(Select);

                    switch (Select)
                    {
                   
                        case "0":
                            Console.Clear();
                            isItemNum = false;
                            Select_Page();
                            isSelect = true;
                            break;
                        default:

                            ShopList_Chk.BuyItem(ItemNum);
                            break;

                    }

                }
                isSelect = false;
                isItemNum = false;

            }


        }
       
        

        public static void Dungeon_Page()
        {



        }


        public void Rest_Page()
        {
            Console.WriteLine("휴식하기");
            Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)", PlayerInfo.Gold);

            Console.WriteLine("1. 휴식하기\n0. 나가기");


            while (!isSelect)
            {
                String Select = Console.ReadLine();

                switch (Select)
                {
                    case "1":
                        if (PlayerInfo.Gold >= 500 && PlayerInfo.HP < 100)
                        {
                            Console.WriteLine("무사히 체력을 회복했습니다");
                            PlayerInfo.Gold -= 500;
                            PlayerInfo.HP = 100;

                        }
                        else if (PlayerInfo.Gold < 500)
                            Console.WriteLine("Gold가 부족합니다.");
                        else if (PlayerInfo.HP == 100)
                            Console.WriteLine("최대 채력입니다.");
                        break;
                    case "0":
                        Select_Page();
                        isSelect = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력하세요");
                        break;

                }

            }
            isSelect = false;
        }



    }





    internal class Program
    {

     
        static void Main(string[] args)
        {

            var GameScene = new Screen_Page();

            GameScene.GameLoad();



        }
    }
}
