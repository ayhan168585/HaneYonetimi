using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CategoryAdded = "Kategori eklendi";
        public static string CategoryUpdated = "Kategori güncellendi";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoriesListed = "Kategoriler listelendi";
        public static string CategoryDetailListed = "Detayını istediğiniz kategori";
        public static string ExpenseAdded = "Harcama eklendi";
        public static string ExpenseDeleted = "Harcama silindi";
        public static string ExpenseUpdated = "Harcama güncellendi";
        public static string ExpensesListed = "Harcamalar listelendi";
        public static string ExpenseDetailListed = "Detayını istediğiniz Harcama";
        public static string IncomeAdded = "Gelir eklendi";
        public static string IncomeUpdated = "Gelir güncellendi";
        public static string IncomeDeleted = "Gelir silindi";
        public static string IncomesListed = "Gelirler listelendi";
        public static string IncomeDetailListed = "Detayını istediğiniz gelir";
        public static string MarketItemAdded = "Market ürünü eklendi";
        public static string MarketItemUpdated = "Market ürünü güncellendi";
        public static string MarketItemDeleted = "Market ürünü silindi";
        public static string MarketItemsListed = "Market ürünleri listelendi";
        public static string MarketItemDetailListed = "Detayını istediğiniz market ürünü";
        public static string RoleAdded = "Rol eklendi";
        public static string RoleUpdated = "Rol güncellendi";
        public static string RoleDeleted = "Rol silindi";
        public static string RolesListed = "Roller listelendi";
        public static string RoleDetailListed = "Detayını istediğiniz rol";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UsersListed= "Kullanıcılar listelendi";
        public static string UserDetailListed= "Detayını istediğiniz kullanıcı";
        public static string CategoryNameNotEmpty = "Kategori adı boş olamaz";
        public static string CategoryNameMinLength = "Kategori adı en az iki karakter olabilir";
        public static string UsersInRoleListed = "İstediğiniz role sahip kullanıcılar listelendi";
        public static string IncomeInUserListed = "İstediğiniz kullanıcının gelirleri listelendi";
        public static string IncomeTotalinUserListed = "İstediğiniz kullanıcının toplam geliri listelendi";
        public static string ExpensesListInUser = "İstediğiniz kullanıcının harcamaları listelendi";
        public static string ExpenseTotalInUser = "İstediğiniz kullanıcının toplam harcaması";
        public static string ExpensesListByCategory = "Harcamalar kategorilere göre listelendi.";
        public static string IncomeTotalAllUserListed = "Tüm kullanıcıların toplam geliri listelendi";
        public static string MarketItemsListedByCategory = "İstediğiniz harcamadaki ürünler listelendi";
        public static string UnitAdded = "Birim eklendi";
        public static string UnitUpdated = "Birim güncellendi";
        public static string UnitDeleted="Birim silindi";
        public static string UnitsListed="Birimler listelendi";
        public static string UnitDetailListed="Detayını istediğiniz birim";
        public static string CategoriesWithMarketItemsListed="Kategoriler ve ürünler listelendi";
        public static string CompareIncomeAndExpenseListed="Aylık gelir gider karşılaştırması listelendi";
        public static string categoryWiseExpensesListed="Kategorilere göre yapılan harcamalar listelendi";
        public static string userWiseFinancialsListed="Kullanıcıların gelir gider analizi listelendi";
        public static string DailyReportsListed="Günlük harcama ve gelir raporu listelendi";
        public static string TopCategoriesListed="En fazla harcama yapılan 3 kategori listelendi";
        public static string AverageUserExpenseListed="Kullanıcıların harcama ortalaması oluşturuldu";
        public static string YearlyFinancialsListed="Yıllık toplam harcama ve geliri listelendi";
        public static string TopIncomeSourcesListed="En fazla gelir getiren kaynaklar listelendi";
        public static string MarketItemExpensesListed="Harcamaların ayrıntıları listelendi";
        public static string UserPhotoAdded="Kullanıcı fotoğrafı eklendi";
        public static string TopExpenseMonthOfYearListed="Yılın en fazla harcama yapılan ayı listelendi";
        internal static string? AuthorizationDenied;
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
    }
}
