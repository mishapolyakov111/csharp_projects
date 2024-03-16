using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

internal class LocalFileSystem : IFileSystem
{
    public IDirectoryFactory DirectoryFactory { get; } = new LocalDirectoryFactory();
    public IFileFactory FileFactory { get; } = new LocalFileFactory();

    public string ReadFile(IFile file)
    {
        return new FileInfo(file.AbsolutePath).OpenText().ReadToEnd();
    }

    public void DeleteFile(IFile file)
    {
        var fileInfo = new FileInfo(file.AbsolutePath);
        fileInfo.Delete();
    }

    public void MoveFile(IFile file, IDirectory destination)
    {
        var fileInfo = new FileInfo(file.AbsolutePath);
        fileInfo.MoveTo(destination.AbsolutePath + '\\' + file.Name);
    }

    public void RenameFile(IFile file, string newName)
    {
        throw new System.NotImplementedException();
    }

    public void CopyFile(IFile file, IDirectory destination)
    {
        var fileInfo = new FileInfo(file.AbsolutePath);
        fileInfo.CopyTo(destination.AbsolutePath + '\\' + file.Name, true);
    }
}