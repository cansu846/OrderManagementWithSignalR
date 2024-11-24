using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_order_orderdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Feature",
            //    table: "Feature");

            //migrationBuilder.RenameTable(
            //    name: "Feature",
            //    newName: "Features");

            //migrationBuilder.RenameColumn(
            //    name: "TestimonialId",
            //    table: "Testimonials",
            //    newName: "TestimonialID");

            //migrationBuilder.RenameColumn(
            //    name: "SocialMediaId",
            //    table: "SocialMedias",
            //    newName: "SocialMediaID");

            //migrationBuilder.RenameColumn(
            //    name: "ProductId",
            //    table: "Products",
            //    newName: "ProductID");

            //migrationBuilder.RenameColumn(
            //    name: "Status",
            //    table: "Products",
            //    newName: "ProductStatus");

            //migrationBuilder.RenameColumn(
            //    name: "Name",
            //    table: "Products",
            //    newName: "ProductName");

            //migrationBuilder.RenameColumn(
            //    name: "DiscountId",
            //    table: "Discounts",
            //    newName: "DiscountID");

            //migrationBuilder.RenameColumn(
            //    name: "ContactId",
            //    table: "Contacts",
            //    newName: "ContactID");

            //migrationBuilder.RenameColumn(
            //    name: "FeatureDescription",
            //    table: "Contacts",
            //    newName: "OpenHours");

            //migrationBuilder.RenameColumn(
            //    name: "CategoryId",
            //    table: "Categories",
            //    newName: "CategoryID");

            //migrationBuilder.RenameColumn(
            //    name: "Status",
            //    table: "Categories",
            //    newName: "CategoryStatus");

            //migrationBuilder.RenameColumn(
            //    name: "Name",
            //    table: "Categories",
            //    newName: "CategoryName");

            //migrationBuilder.RenameColumn(
            //    name: "BookingId",
            //    table: "Bookings",
            //    newName: "BookingID");

            //migrationBuilder.RenameColumn(
            //    name: "FeatureId",
            //    table: "Features",
            //    newName: "FeatureID");

            //migrationBuilder.AddColumn<int>(
            //    name: "CategoryID",
            //    table: "Products",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<bool>(
            //    name: "Status",
            //    table: "Discounts",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "FooterDescription",
            //    table: "Contacts",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "FooterTitle",
            //    table: "Contacts",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "OpenDays",
            //    table: "Contacts",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "OpenDaysDescription",
            //    table: "Contacts",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Description",
            //    table: "Bookings",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<int>(
            //    name: "PersonCount",
            //    table: "Bookings",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<bool>(
            //    name: "Status",
            //    table: "Bookings",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Features",
            //    table: "Features",
            //    column: "FeatureID");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "Date", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_CategoryID",
            //    table: "Products",
            //    column: "CategoryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderDetails_OrderID",
            //    table: "OrderDetails",
            //    column: "OrderID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderDetails_ProductID",
            //    table: "OrderDetails",
            //    column: "ProductID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Products_Categories_CategoryID",
            //    table: "Products",
            //    column: "CategoryID",
            //    principalTable: "Categories",
            //    principalColumn: "CategoryID",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Products_Categories_CategoryID",
        //        table: "Products");

        //    migrationBuilder.DropTable(
        //        name: "OrderDetails");

        //    migrationBuilder.DropTable(
        //        name: "Orders");

        //    migrationBuilder.DropIndex(
        //        name: "IX_Products_CategoryID",
        //        table: "Products");

        //    migrationBuilder.DropPrimaryKey(
        //        name: "PK_Features",
        //        table: "Features");

        //    migrationBuilder.DropColumn(
        //        name: "CategoryID",
        //        table: "Products");

        //    migrationBuilder.DropColumn(
        //        name: "Status",
        //        table: "Discounts");

        //    migrationBuilder.DropColumn(
        //        name: "FooterDescription",
        //        table: "Contacts");

        //    migrationBuilder.DropColumn(
        //        name: "FooterTitle",
        //        table: "Contacts");

        //    migrationBuilder.DropColumn(
        //        name: "OpenDays",
        //        table: "Contacts");

        //    migrationBuilder.DropColumn(
        //        name: "OpenDaysDescription",
        //        table: "Contacts");

        //    migrationBuilder.DropColumn(
        //        name: "Description",
        //        table: "Bookings");

        //    migrationBuilder.DropColumn(
        //        name: "PersonCount",
        //        table: "Bookings");

        //    migrationBuilder.DropColumn(
        //        name: "Status",
        //        table: "Bookings");

        //    migrationBuilder.RenameTable(
        //        name: "Features",
        //        newName: "Feature");

        //    migrationBuilder.RenameColumn(
        //        name: "TestimonialID",
        //        table: "Testimonials",
        //        newName: "TestimonialId");

        //    migrationBuilder.RenameColumn(
        //        name: "SocialMediaID",
        //        table: "SocialMedias",
        //        newName: "SocialMediaId");

        //    migrationBuilder.RenameColumn(
        //        name: "ProductID",
        //        table: "Products",
        //        newName: "ProductId");

        //    migrationBuilder.RenameColumn(
        //        name: "ProductStatus",
        //        table: "Products",
        //        newName: "Status");

        //    migrationBuilder.RenameColumn(
        //        name: "ProductName",
        //        table: "Products",
        //        newName: "Name");

        //    migrationBuilder.RenameColumn(
        //        name: "DiscountID",
        //        table: "Discounts",
        //        newName: "DiscountId");

        //    migrationBuilder.RenameColumn(
        //        name: "ContactID",
        //        table: "Contacts",
        //        newName: "ContactId");

        //    migrationBuilder.RenameColumn(
        //        name: "OpenHours",
        //        table: "Contacts",
        //        newName: "FeatureDescription");

        //    migrationBuilder.RenameColumn(
        //        name: "CategoryID",
        //        table: "Categories",
        //        newName: "CategoryId");

        //    migrationBuilder.RenameColumn(
        //        name: "CategoryStatus",
        //        table: "Categories",
        //        newName: "Status");

        //    migrationBuilder.RenameColumn(
        //        name: "CategoryName",
        //        table: "Categories",
        //        newName: "Name");

        //    migrationBuilder.RenameColumn(
        //        name: "BookingID",
        //        table: "Bookings",
        //        newName: "BookingId");

        //    migrationBuilder.RenameColumn(
        //        name: "FeatureID",
        //        table: "Feature",
        //        newName: "FeatureId");

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_Feature",
        //        table: "Feature",
        //        column: "FeatureId");
        //
        }
    }
}
