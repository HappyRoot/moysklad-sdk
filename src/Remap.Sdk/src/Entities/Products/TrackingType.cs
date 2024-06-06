using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an tracking type.
    /// </summary>
    public enum TrackingType
    {
        /// <summary>
        /// Not tracked.
        /// </summary>
        [EnumMember(Value = "NOT_TRACKED")]
        NotTracked,

        /// <summary>
        /// Tobacco tracking type.
        /// </summary>
        [EnumMember(Value = "TOBACCO")]
        Tobacco,

        /// <summary>
        /// Shoes tracking type.
        /// </summary>
        [EnumMember(Value = "SHOES")]
        Shoes,

        /// <summary>
        /// Clothes tracking type.
        /// </summary>
        [EnumMember(Value = "LP_CLOTHES")]
        Clothes,

        /// <summary>
        /// Linens tracking type.
        /// </summary>
        [EnumMember(Value = "LP_LINENS")]
        Linens,

        /// <summary>
        /// Perfumery tracking type.
        /// </summary>
        [EnumMember(Value = "PERFUMERY")]
        Perfumery,

        /// <summary>
        /// Electronics tracking type.
        /// </summary>
        [EnumMember(Value = "ELECTRONICS")]
        Electronics,

        /// <summary>
        /// Tires tracking type.
        /// </summary>
        [EnumMember(Value = "TIRES")]
        Tires,

        /// <summary>
        /// Tracking type for OTP products.
        /// </summary>
        [EnumMember(Value = "OTP")]
        Otp,
        /// <summary>
        /// Tracking type for Milk products.
        /// </summary>
        [EnumMember(Value = "MILK")]
        Milk,
        /// <summary>
        /// Tracking type for Beer products.
        /// </summary>
        [EnumMember(Value = "BEER_ALCOHOL")]
        BeerAlcohol,
        /// <summary>
        /// Tracking type for NCP products.
        /// </summary>
        [EnumMember(Value = "NCP")]
        NCP,
        /// <summary>
        /// Tracking type for NCP products.
        /// </summary>
        [EnumMember(Value = "WATER")]
        Water,
        /// <summary>
        /// Tracking type for FOOD_SUPPLEMENT products.
        /// </summary>
        [EnumMember(Value = "FOOD_SUPPLEMENT")]
        FoodSupplement,
        /// <summary>
        /// Tracking type for SANITIZER products.
        /// </summary>
        [EnumMember(Value = "SANITIZER")]
        SANITIZER,
    }
}