using System;
using FluentMigrator.Builders.Alter.Table;

namespace Rat.DataStorage.Migrations
{
    public partial interface IAlterationTableManager
    {
        void AlterTableExpressions(Type type, AlterTableExpressionBuilder builder);
    }
}
