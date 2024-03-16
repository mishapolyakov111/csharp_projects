using Itmo.ObjectOrientedProgramming.Lab4.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    IDirectoryFactory DirectoryFactory { get; }
    IFileFactory FileFactory { get; }
    string ReadFile(IFile file);
    void DeleteFile(IFile file);
    void MoveFile(IFile file, IDirectory destination);
    void RenameFile(IFile file, string newName);
    void CopyFile(IFile file, IDirectory destination);
}