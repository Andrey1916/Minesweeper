namespace Minesweeper.DataAccess.Entities;

public interface IEntity<out T>
{
    T Id { get; }
}