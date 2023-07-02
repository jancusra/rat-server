using System;
using FluentMigrator.Builders.Alter;
using FluentMigrator.Builders.Create;
using FluentMigrator.Expressions;

namespace Rat.DataStorage.Migrations
{
    public partial interface ICreationTableManager
    {
        void CreateOrAlterTable<TEntity>(ICreateExpressionRoot createExpressionRoot, IAlterExpressionRoot alterExpressionRoot);

        CreateTableExpression GetCreateTableExpression(Type type);
    }
}
