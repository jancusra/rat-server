using FluentMigrator;
using Rat.Domain.Entities;

namespace Rat.DataStorage.Migrations
{
    [Migration(1676057321)]
    public partial class DbSchemaMigration : AutoReversingMigration
    {
        private readonly ICreationTableManager _creationTableManager;

        public DbSchemaMigration(ICreationTableManager creationTableManager)
        {
            _creationTableManager = creationTableManager;
        }

        public override void Up()
        {
            _creationTableManager.CreateOrAlterTable<MenuItem>(Create, Alter);
            _creationTableManager.CreateOrAlterTable<User>(Create, Alter);
            _creationTableManager.CreateOrAlterTable<UserPassword>(Create, Alter);
            _creationTableManager.CreateOrAlterTable<UserRole>(Create, Alter);
            _creationTableManager.CreateOrAlterTable<UserRoleException>(Create, Alter);
            _creationTableManager.CreateOrAlterTable<UserUserRoleMap>(Create, Alter);
        }
    }
}