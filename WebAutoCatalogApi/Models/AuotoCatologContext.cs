using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAutoCatalogApi.Models
{
    public partial class AuotoCatologContext : DbContext
    {
        public AuotoCatologContext()
        {
        }

        public AuotoCatologContext(DbContextOptions<AuotoCatologContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyType> BodyTypes { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Characteristic> Characteristics { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Expert> Experts { get; set; } = null!;
        public virtual DbSet<FeedBack> FeedBacks { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<Recommendation> Recommendations { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Stamp> Stamps { get; set; } = null!;
        public virtual DbSet<TestDrife> TestDrives { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.ToTable("Body_type");

                entity.Property(e => e.BodyTypeId).HasColumnName("body_type_id");

                entity.Property(e => e.BodyTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("body_type_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarId).HasColumnName("Car_id");

                entity.Property(e => e.BodyTypeId).HasColumnName("body_type_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DateOfRelease)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_release");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.IdChar).HasColumnName("id_char");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.StampId).HasColumnName("stamp_id");

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Body_type");

                entity.HasOne(d => d.IdCharNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.IdChar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Characteristic");

                entity.HasOne(d => d.Stamp)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.StampId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Stamp");
            });

            modelBuilder.Entity<Characteristic>(entity =>
            {
                entity.HasKey(e => e.IdChar)
                    .HasName("PK__Characte__68D484D35A51EE82");

                entity.ToTable("Characteristic");

                entity.Property(e => e.IdChar).HasColumnName("id_char");

                entity.Property(e => e.CarHeight)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Car_height");

                entity.Property(e => e.CarLength)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Car_length");

                entity.Property(e => e.CarWidth)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Car_width");

                entity.Property(e => e.EngineModel)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("engine_model");

                entity.Property(e => e.EnginePower)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("engine_power");

                entity.Property(e => e.Gearbox)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gearbox");

                entity.Property(e => e.GroundClearance)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Ground_clearance");

                entity.Property(e => e.NumberOfGears).HasColumnName("number_of_gears");

                entity.Property(e => e.Speed)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("speed");

                entity.Property(e => e.TypeOfDrive)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_of_drive");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CommentText)
                    .HasColumnType("text")
                    .HasColumnName("comment_text");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.IdNews).HasColumnName("id_news");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdNewsNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdNews)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_News");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Users");
            });

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.Property(e => e.ExpertId).HasColumnName("expert_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ExpertName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("expert_name");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("specialization");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.ToTable("FeedBack");

                entity.Property(e => e.FeedBackId).HasColumnName("feed_back_id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.FeedbackLike).HasColumnName("feedback_like");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.FeedBacks)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeedBack_Comment");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.IdNews)
                    .HasName("PK__News__389F1DA989F92D8B");

                entity.Property(e => e.IdNews).HasColumnName("id_news");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.Heading)
                    .HasColumnType("text")
                    .HasColumnName("heading");

                entity.Property(e => e.NewsText)
                    .HasColumnType("text")
                    .HasColumnName("news_text");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("date")
                    .HasColumnName("publication_date");
            });

            modelBuilder.Entity<Recommendation>(entity =>
            {
                entity.HasKey(e => e.IdRec)
                    .HasName("PK__Recommen__6ABE6F08BB232658");

                entity.ToTable("Recommendation");

                entity.Property(e => e.IdRec).HasColumnName("id_rec");

                entity.Property(e => e.CarId).HasColumnName("Car_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.ExpertId).HasColumnName("expert_id");

                entity.Property(e => e.RecommendationText)
                    .HasColumnType("text")
                    .HasColumnName("recommendation_text");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recommendation_Car");

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.ExpertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recommendation_Experts");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.CarId).HasColumnName("Car_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DateOfPublication)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_publication");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.ReviewText)
                    .HasColumnType("text")
                    .HasColumnName("review_text");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Car");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Users");
            });

            modelBuilder.Entity<Stamp>(entity =>
            {
                entity.ToTable("Stamp");

                entity.Property(e => e.StampId).HasColumnName("stamp_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.StampName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stamp_name");
            });

            modelBuilder.Entity<TestDrife>(entity =>
            {
                entity.HasKey(e => e.IdTest)
                    .HasName("PK__Test_dri__C6D3284B4C765D4E");

                entity.ToTable("Test_drives");

                entity.Property(e => e.IdTest).HasColumnName("id_test");

                entity.Property(e => e.CarId).HasColumnName("Car_id");

                entity.Property(e => e.Comfort)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.EngineOperation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Engine_operation");

                entity.Property(e => e.LenghtDriveRouteKm).HasColumnName("Lenght_drive_route_km");

                entity.Property(e => e.SoundInsulationQuality)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Sound_insulation_quality");

                entity.Property(e => e.TestDate)
                    .HasColumnType("date")
                    .HasColumnName("test_date");

                entity.Property(e => e.VisibilityAndManagebility)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Visibility_and_managebility");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.TestDrives)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Test_drives_Car");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__D2D14637CB2FFA98");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.DateOfRegistration)
                    .HasColumnType("date")
                    .HasColumnName("date_of_registration");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_User_Role");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__User_Rol__760965CC0F0FE529");

                entity.ToTable("User_Role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("date")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
