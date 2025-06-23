using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGetAuthorsSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = """
                CREATE OR ALTER   PROCEDURE [dbo].[GetAuthors]
                	@PageIndex int,
                	@PageSize int,
                	@OrderBy nvarchar(50),
                	@Name nvarchar(max) = '%',
                	@Biography nvarchar(max) = '%',
                	@RatingFrom int = NULL,
                	@RatingTo int = NULL,
                	@Total int OUTPUT,
                	@TotalDisplay int OUTPUT
                AS
                Begin
                	SET NOCOUNT ON;
                	DECLARE @sql nvarchar(2000);
                	DECLARE @countSql nvarchar(2000);
                	DECLARE @paramList nvarchar(MAX);
                	DECLARE @countparamList nvarchar(MAX);

                	SELECT @Total = COUNT(*) from Authors;

                	SET @countSql = 'SELECT @TotalDisplay = COUNT(*) from Authors a where 1 = 1';

                	SET @countSql = @countSql + ' AND a.Name LIKE ''%'' + @xName + ''%''';

                	SET @countSql = @countSql + ' AND a.Biography LIKE ''%'' + @xBiography + ''%''';

                	IF @RatingFrom IS NOT NULL
                	SET @countSql = @countSql + ' AND a.Rating >= @xRatingFrom';

                	IF @RatingTo IS NOT NULL
                	SET @countSql = @countSql + ' AND a.Rating <= @xRatingTo';

                	SELECT @countparamList = '@xName nvarchar(max),
                	@xBiography nvarchar(max),
                	@xRatingFrom int,
                	@xRatingTo int,
                	@TotalDisplay int output';

                	exec sp_executesql @countSql,@countparamList,
                	@Name,
                	@Biography,
                	@RatingFrom,
                	@RatingTo,
                	@TotalDisplay = @TotalDisplay output;

                	SET @sql = 'SELECT * from Authors a where 1 = 1';

                	SET @sql = @sql + ' AND a.Name LIKE ''%'' + @xName + ''%''';

                	SET @sql = @sql + ' AND a.Biography LIKE ''%'' + @xBiography + ''%''';

                	IF @RatingFrom IS NOT NULL
                	SET @sql = @sql + ' AND a.Rating >= @xRatingFrom';

                	IF @RatingFrom IS NOT NULL
                	SET @sql = @sql + ' AND a.Rating <= @xRatingTo';

                	SET @sql = @sql + ' ORDER BY ' + @OrderBy + ' OFFSET @PageSize * (@PageIndex - 1)
                	ROWS FETCH NEXT @PageSize ROWS ONLY';

                	SELECT @paramList = '@xName nvarchar(max),
                	@xBiography nvarchar(max),
                	@xRatingFrom int,
                	@xRatingTo int,
                	@PageIndex int,
                	@PageSize int';

                	exec sp_executesql @sql,@paramList,
                	@Name,
                	@Biography,
                	@RatingFrom,
                	@RatingTo,
                	@PageIndex,
                	@PageSize;

                	print @sql;
                	print @countSql;

                End
                """;
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = "DROP PROCEDURE IF EXISTS [dbo].[GetAuthors]";
            migrationBuilder.Sql(sql);
        }
    }
}
