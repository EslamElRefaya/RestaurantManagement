using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagement_Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOnTbsReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodReview_Foods_FoodId",
                table: "FoodReview");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantReview_Restaurants_RestaurantId",
                table: "RestaurantReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantReview",
                table: "RestaurantReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodReview",
                table: "FoodReview");

            migrationBuilder.RenameTable(
                name: "RestaurantReview",
                newName: "RestaurantReviews");

            migrationBuilder.RenameTable(
                name: "FoodReview",
                newName: "FoodReviews");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantReview_RestaurantId",
                table: "RestaurantReviews",
                newName: "IX_RestaurantReviews_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodReview_FoodId",
                table: "FoodReviews",
                newName: "IX_FoodReviews_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantReviews",
                table: "RestaurantReviews",
                column: "RestaurantReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodReviews",
                table: "FoodReviews",
                column: "FoodReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodReviews_Foods_FoodId",
                table: "FoodReviews",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantReviews_Restaurants_RestaurantId",
                table: "RestaurantReviews",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodReviews_Foods_FoodId",
                table: "FoodReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantReviews_Restaurants_RestaurantId",
                table: "RestaurantReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantReviews",
                table: "RestaurantReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodReviews",
                table: "FoodReviews");

            migrationBuilder.RenameTable(
                name: "RestaurantReviews",
                newName: "RestaurantReview");

            migrationBuilder.RenameTable(
                name: "FoodReviews",
                newName: "FoodReview");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantReviews_RestaurantId",
                table: "RestaurantReview",
                newName: "IX_RestaurantReview_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodReviews_FoodId",
                table: "FoodReview",
                newName: "IX_FoodReview_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantReview",
                table: "RestaurantReview",
                column: "RestaurantReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodReview",
                table: "FoodReview",
                column: "FoodReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodReview_Foods_FoodId",
                table: "FoodReview",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantReview_Restaurants_RestaurantId",
                table: "RestaurantReview",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
