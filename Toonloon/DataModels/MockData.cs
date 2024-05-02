using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toonloon.DataModels
{
    public class MockData
    {
        public List<Manga> MangaList = MockList();

        private static List<Manga> MockList()
        {
            List<Manga> list = new List<Manga>();
            var manga1 = new Manga()
            {
                MangaTitle = "Isekai Walking",
                Author = "Aruku Hito",
                CoverURL = "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2F10001.jpg?alt=media&token=8408354b-88ec-490f-91aa-0a37965657f9",
                MangaID = 1,
                Chapters = new[] {
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10001.jpg?alt=media&token=fc9832a8-1934-431e-b02a-65188f0c9dbb",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10002.png?alt=media&token=8cd3efb2-eb06-4fb6-a220-1750f0619c6b",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10003.png?alt=media&token=8601d1b2-09e0-4f4d-8eb7-9cb36a00b566",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10004.png?alt=media&token=429271a6-66ce-4a58-847a-201f52e577e7",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10005.jpg?alt=media&token=5c49b271-38da-4913-83ec-e89f871605b4",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10006.jpg?alt=media&token=0eeabcad-8f39-4d3a-92ac-28d8332e3297",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10007.png?alt=media&token=ffa63c83-e2f7-48e5-9bc8-5a1eb4a3ca67",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10008.png?alt=media&token=90950dbd-a2ec-433f-9481-2e7941705661",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10009.png?alt=media&token=8a25443e-9065-4030-891d-f03bfd6fe899",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10010.jpg?alt=media&token=b7c923c9-3523-4273-8042-6d9191db9083",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10011.png?alt=media&token=d04f9209-de30-4b1c-b8f2-bbf46b3ae1aa",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10012.png?alt=media&token=2b52fab9-af75-43d7-8933-0e9c72a26424",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10013.png?alt=media&token=2c90ede2-3051-40f2-be95-adcc2d04d7ba",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10014.png?alt=media&token=8965a1c4-a3ea-493c-8efe-375ef0c515b0",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10015.png?alt=media&token=f4036a38-b0c3-47cf-8ced-a0931203aed6",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10016.png?alt=media&token=889412fb-02bc-4665-89cb-50225da55fa5",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10017.png?alt=media&token=98e3f47c-05a1-4aa8-8c1c-7407a19f6444",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10018.png?alt=media&token=9fc1432c-22e3-44a2-8f3a-c577080ee065",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10019.png?alt=media&token=87fe3006-4f7b-45c1-8fe1-d3419e2a77a2",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10020.png?alt=media&token=51c7d4f3-1a72-408e-af41-e779ebf85e4a",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10021.png?alt=media&token=6f6d5c1e-32ac-41fb-8072-dd81d4dba14e",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10022.png?alt=media&token=ebce77bb-65c0-4c37-ac7e-8b3250c94ba8",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10023.png?alt=media&token=49a9aecd-8978-4ae1-a743-57f9bfacb38e",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10024.png?alt=media&token=71c57ac5-b95d-42bc-a015-143f519e0a3f",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10025.png?alt=media&token=078d958d-2b03-4d05-88b1-6603132c9aca",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10026.png?alt=media&token=34bccbf2-5f79-45ce-8afd-05d1c4f10fd5",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10027.png?alt=media&token=47f91d9b-0e56-416b-9184-6cbf7daa7d9c",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10028.png?alt=media&token=c5c5f33b-939a-470b-9717-5e9cc6bae5cb",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10029.png?alt=media&token=3048cfd6-8da0-41b4-a226-5f2e0adedfdf",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10030.png?alt=media&token=76d8b7ba-b778-41b4-aa11-60f318406f1c",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10031.png?alt=media&token=335ac23b-0af7-4d10-ad5a-e313a2572eab",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10032.png?alt=media&token=c7944e36-e0cb-4245-a5ec-25c287845a10",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10033.png?alt=media&token=542ce842-8cf8-4f54-acde-7c9b5f5ba64a",
  "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FIsekai%20Walking%2FChapter%201%2F10034.png?alt=media&token=ab8777e9-5788-403f-a44d-b5c432e9dea6"}

            };
            var manga2 = new Manga()
            {
                MangaTitle = "Fuchou Airen",
                CoverURL = "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2F10001.jpg?alt=media&token=d820596b-a389-453d-8915-ea174319f049",
                MangaID= 2,
                Chapters = new[] {
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10001.jpg?alt=media&token=5ca62d72-f4ba-4f17-a144-60ec6f49d1ca",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10002.jpg?alt=media&token=41585ebd-6fd7-4251-9442-1c568439843d",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10003.jpg?alt=media&token=c3133a90-5418-4d78-a6ff-f53b4e8e4a2e",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10004.jpg?alt=media&token=6d637c37-6c3e-4cde-9ced-3cf434bf5224",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10005.jpg?alt=media&token=3a48e9ac-71ab-41bf-b99e-0008cc0d4871",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10006.jpg?alt=media&token=5cebd522-8122-4d56-809f-e2e714c71682",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10007.jpg?alt=media&token=1b998295-7431-4b5a-bf78-6d0925504bd8",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10008.jpg?alt=media&token=fd51bab0-fd62-4cc6-9c79-8c6d102d71c9",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10009.jpg?alt=media&token=933e6fe3-b607-4fbb-81d3-374a7d556735",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10010.jpg?alt=media&token=1ab2d39e-0c3f-44e9-bb48-6688734bf0ff",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10011.jpg?alt=media&token=a5db4e1f-e140-465e-8cd1-70a7618550d2",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10012.jpg?alt=media&token=c762e1a5-3f64-4a02-9a8f-c8f8fd88a87f",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10013.jpg?alt=media&token=2af6c462-e97e-4aee-986e-e80eede26c63",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10014.jpg?alt=media&token=856f99ff-46ef-4eb0-b1a6-2e908fae1fe6",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10015.jpg?alt=media&token=70759d6e-6c8f-42bd-a021-202bba88a6f1",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10016.jpg?alt=media&token=976fd30a-79fb-4ef8-bbec-d64e721dc930",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10017.jpg?alt=media&token=3133f4b0-00bd-4181-8793-9097673c5c02",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10018.jpg?alt=media&token=4b60b0b2-2dbc-46d9-8b87-041ebe377ef7",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10019.jpg?alt=media&token=ec98a6a0-69a4-4de6-b426-af1c2ce9f8e8",
    "https://firebasestorage.googleapis.com/v0/b/toonloon-cbfce.appspot.com/o/Toons%2FFuchou%20Airen%2FChapter%201%2F10020.jpg?alt=media&token=f4dde321-d451-4903-88f9-9604185b1bd7"}
        };

            list.Add(manga1);
            list.Add (manga2);

            return list;
        }
    }
}